import os

directory = r'./dlls'

dll_files = [f for f in os.listdir(directory) if os.path.isfile(os.path.join(directory, f)) and f.endswith('.dll')]

for dll in dll_files:
    print(f'''
    <Reference Include="{dll[:-4]}">
      <HintPath>{os.path.normpath(os.path.join(directory, dll))}</HintPath>
    </Reference>
    ''')