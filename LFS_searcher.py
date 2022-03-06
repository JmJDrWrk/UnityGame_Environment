import os
from termcolor import colored

for dirname, dirnames, filenames in os.walk('.'):
    # print path to all subdirectories first.
    for subdirname in dirnames:
        #print(f'{os.path.join(dirname, subdirname)} -- {os.path.getsize(os.path.join(dirname, subdirname))} ')
        pass

    # print path to all filenames.
    for filename in filenames:
        filesize = os.path.getsize(os.path.join(dirname, filename))/(1024*1024)
        if(filesize>90): print(colored(f'LFS -- ','red') + colored(f'{os.path.join(dirname, filename)}','magenta') + colored(f' -->{filesize} Mb','yellow'))
        #print(f'{os.path.join(dirname, subdirname)} -- {filesize} MegaBytes')
        



