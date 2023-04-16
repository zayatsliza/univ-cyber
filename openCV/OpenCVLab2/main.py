import cv2
import numpy as np
from os import listdir
from os.path import isfile, join, isdir
from PIL import Image
onlydirs = [f for f in listdir("models/letters") if isdir(join("models/letters", f))]

def avg_for_files_in_dir(hash1,dirname):
    imgfiles= [f for f in listdir("models/letters/"+dirname) if isfile(join("models/letters/"+dirname, f))]
    allcomparesfordir = []
    for ex in imgfiles:
        img = cv2.imread('models/letters/'+dirname+'/'+ ex)
        hash2 = CalcImageHash(img)
        compare=CompareHash(hash1, hash2)
        allcomparesfordir.append(compare)
    return allcomparesfordir

def find_min(dictcompares):
    minv=10000
    letter=""
    for key in dictcompares:
        values=dictcompares[key]
        if min(values)<minv:
            minv=min(values)
            letter=key
    return letter


def CalcImageHash(image):
    gen_size=100
    image = cv2.resize(image, (gen_size, gen_size), interpolation=cv2.INTER_AREA)
    avg = image.mean()
    ret, threshold_image = cv2.threshold(image, avg, 255, 0)
    _hash = ""
    for x in range(gen_size):
        for y in range(gen_size):
            val = threshold_image[x, y]
            if isinstance(val, (np.ndarray) ):
                if val[0] == 255 and val[1]==255 and val[2]==255:
                    _hash = _hash + "1"
                else:
                    _hash = _hash + "0"
            else:
                if val==255:
                    _hash = _hash + "1"
                else:
                    _hash = _hash + "0"

    return _hash


def CompareHash(hash1, hash2):
    l = len(hash1)
    i = 0
    count = 0
    while i < l:
        if hash1[i] != hash2[i]:
            count = count + 1
        i = i + 1
    return count


def letters_extract(image_file: str, out_size=100):
    img = cv2.imread(image_file)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    ret, thresh = cv2.threshold(gray, 0, 255, cv2.THRESH_BINARY)
    img_erode = cv2.erode(thresh, np.ones((3, 3), np.uint8), iterations=1)
    # Get contours
    contours, hierarchy = cv2.findContours(img_erode, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)
    output = img.copy()
    letters = []
    for idx, contour in enumerate(contours):
        (x, y, w, h) = cv2.boundingRect(contour)
        if hierarchy[0][idx][3] == 0:
            cv2.rectangle(output, (x, y), (x + w, y + h), (70, 0, 0), 1)
            letter_crop = gray[y:y + h, x:x + w]
            # Resize letter canvas to square
            size_max = max(w, h)
            letter_square = 255 * np.ones(shape=[size_max, size_max], dtype=np.uint8)
            if w > h:
                # Enlarge image top-bottom
                y_pos = size_max//2 - h//2
                letter_square[y_pos:y_pos + h, 0:w] = letter_crop
            elif w < h:
                # Enlarge image left-right
                # --||--
                x_pos = size_max//2 - w//2
                letter_square[0:h, x_pos:x_pos + w] = letter_crop
            else:
                letter_square = letter_crop

            # Resize letter to 28x28 and add letter and its X-coordinate
            letters.append((x, w, cv2.resize(letter_square, (out_size, out_size), interpolation=cv2.INTER_AREA)))
    # Sort array in place by X-coordinate
    letters.sort(key=lambda x: x[0], reverse=False)
    return letters

letters=letters_extract("models/textWords/img.png")
for l in range(0,len(letters)):
    (thresh, black) = cv2.threshold(letters[l][2], 127, 255, cv2.THRESH_BINARY)
    hash1 = CalcImageHash(black)
    allcompares= {}
    for dir in onlydirs:
        allcompares[dir]=avg_for_files_in_dir(hash1,dir)
    bestVal=find_min(allcompares)
    print(bestVal)
    cv2.imshow(bestVal,letters[l][2])
print('\n==========================')

cv2.waitKey(0)