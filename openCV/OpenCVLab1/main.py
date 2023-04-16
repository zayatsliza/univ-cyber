import cv2 as cv
from matplotlib import pyplot as plt

src_base = cv.imread('models/1.png')
src_test1 = cv.imread('models/2.png')
src_test2 = cv.imread('models/3.png')
src_test3 = cv.imread('models/4.png')

if src_base is None or src_test3 is None:
    print('Could not open images')
    exit(0)

hsv_base = cv.cvtColor(src_base, cv.COLOR_BGR2HSV)
hsv_test1 = cv.cvtColor(src_test1, cv.COLOR_BGR2HSV)
hsv_test2 = cv.cvtColor(src_test2, cv.COLOR_BGR2HSV)
hsv_test3 = cv.cvtColor(src_test3, cv.COLOR_BGR2HSV)

hsv_half_down = hsv_base[hsv_base.shape[0] // 2:, :]
h_bins = 100
s_bins = 100
histSize = [h_bins, s_bins]
# hue varies from 0 to 179, saturation from 0 to 255
h_ranges = [0, 180]
s_ranges = [0, 256]
ranges = h_ranges + s_ranges  # concat lists

# Use the 0-th and 1-st channels
channels = [0, 1]

hist_base = cv.calcHist([hsv_base], channels, None, histSize, ranges, accumulate=False)
cv.normalize(hist_base, hist_base, alpha=0, beta=1, norm_type=cv.NORM_MINMAX)
hist_test1 = cv.calcHist([hsv_test1], channels, None, histSize, ranges, accumulate=False)
cv.normalize(hist_test1, hist_test1, alpha=0, beta=1, norm_type=cv.NORM_MINMAX)
hist_test2 = cv.calcHist([hsv_test2], channels, None, histSize, ranges, accumulate=False)
cv.normalize(hist_test2, hist_test2, alpha=0, beta=1, norm_type=cv.NORM_MINMAX)
hist_test3 = cv.calcHist([hsv_test3], channels, None, histSize, ranges, accumulate=False)
cv.normalize(hist_test3, hist_test3, alpha=0, beta=1, norm_type=cv.NORM_MINMAX)

color = ('b', 'g', 'r')
for i, col in enumerate(color):
    histr = cv.calcHist([hsv_test3], [i], None, [256], [0, 256])
    plt.plot(histr, color=col)
    plt.xlim([0, 256])
plt.show()


for compare_method in range(4):
    base_base = cv.compareHist(hist_base, hist_base, compare_method)
    base_test1 = cv.compareHist(hist_base, hist_test1, compare_method)
    base_test2 = cv.compareHist(hist_base, hist_test2, compare_method)
    base_test3 = cv.compareHist(hist_base, hist_test3, compare_method)

    print('Method:', compare_method, '(1-1), (1-2), (1-3), (1-4) :',
          base_base, '/', base_test1, '/', base_test2, '/', base_test3, )
