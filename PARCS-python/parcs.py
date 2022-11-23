

# import gmpy2
from Pyro4 import expose
import random

from joblib.numpy_pickle_utils import xrange


class Solver:
    def __init__(self, workers=None, input_file_name=None, output_file_name=None):
        self.input_file_name = input_file_name
        self.output_file_name = output_file_name
        self.workers = workers
        print("Inited")

    def solve(self):
        print("Job Started")
        print("Workers %d" % len(self.workers))

        (a, b) = self.read_input()
        step_n = (b - a) / len(self.workers)

        # map
        mapped = []
        for i in xrange(0, len(self.workers)):
            print("map %d" % i)
            mapped.append(self.workers[i].mymap(str(a + i * step_n), str(a + (i + 1) * step_n)))

        # reduce
        primes = self.myreduce(mapped)

        # output
        self.write_output(primes)

        print("Job Finished")

    @staticmethod
    @expose
    def mymap(a, b):
      a=int(a)  
      b=int(b)
      mod = 10
      list=[]
      for i in range(a, b + 1):
         if i == mod:
           mod *= 10
         if (i * i) % mod == i:
           list.append(str(i))
      return list       

    @staticmethod
    @expose
    def myreduce(mapped):
        print("reduce")
        output = []

        for primes in mapped:
            print("reduce loop")
            output = output + primes.value
        print("reduce done")
        return output

    def read_input(self):
        f = open(self.input_file_name, 'r')
        n = int(f.readline())
        k = int(f.readline())
        f.close()
        return n, k

    def write_output(self, output):
        f = open(self.output_file_name, 'w')
        f.write(', '.join(output))
        f.write('\n')
        f.close()
        print("output done")