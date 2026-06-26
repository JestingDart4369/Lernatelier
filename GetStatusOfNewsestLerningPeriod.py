"""Script for geting data of the newest Lernperiode Status"""
import os
import subprocess
import argparse
parser = argparse.ArgumentParser()
parser.add_argument(
    '--periode', 
    type=int,
    default=0,
    help='Path to the specific Lernperiode file')
parser.add_argument('--debug', action='store_true', help='Enable debug mode')
args = parser.parse_args()
DEBUG = args.debug
if args.periode == 0:
    FORCELERNPERIODE = ""
else:
    FORCELERNPERIODE = f"Lernperiode-{args.periode}.md"
os.chdir(os.path.dirname(os.path.realpath(__file__)))
if DEBUG:
    print(os.getcwd())
if DEBUG:
    print(os.listdir(os.getcwd()))


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