import os
for element in os.listdir():
    if('.' not in element):
        print(f'git add {element}\ngit commit -m "automated update of {element} inside folderProject"\ngit push')