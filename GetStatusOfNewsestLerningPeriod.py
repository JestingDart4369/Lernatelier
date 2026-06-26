"""Script for geting data of the newest Lernperiode Status"""
import os
import subprocess

DEBUG = True
FORCELERNPERIODE = "Lernperiode-4.md"
cwd=os.getcwd()
if DEBUG:
    print(cwd)
if DEBUG:
    print(os.listdir(cwd))


def sorting(e:any):
    """Function for sorting the Lernperioden by their number"""
    return e.strip('Lernperiode-').strip('.md')

lernperioden = []
for File in (os.listdir(os.getcwd())):
    if File.startswith('Lernperiode'):
        lernperioden.append(File)
lernperioden.sort(reverse=True, key=sorting)
if DEBUG:
    print(lernperioden )
if FORCELERNPERIODE == "":
    file=os.path.join(os.getcwd(), lernperioden[0])
else:
    file=os.path.join(os.getcwd(), FORCELERNPERIODE)
if DEBUG:
    print("newest Lernperiode file: ", file) 
subprocess.run(['lernatelier-checker', file], cwd=os.getcwd())