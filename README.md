# file-list-exporter
FileListExporter allows you to select and export file list without having physical files on your drive

<An example of using FileListExporter>

An employee wants to back up private data later after leaving the company, and the company does not want to leak any of its important information or data.
In this case, the company uses "SpaceSniffer" to send a folder hierarchy and file list in a specific folder on the disk of the PC used by the employee to the employee.
Contents in files are not exposed, so the company's assets can be protected.
The employee uses "FileListExporter" to deliver the list of files they want to back up to the company.
The company uses "FileListExporeter" to exclude the company's assets from the list of selected files and use "FastCopy" to send the files to the employee.

Download SpaceSniffer: http://www.uderzo.it/main_products/space_sniffer/
Download FastCopy: https://fastcopy.jp/en/

<How to use>

1. Export a folder hierarchy and file list using SpaceSniffer
- Run SpaceSniffer
- Select a root folder that contains the folder hierarchy and file list you want to send
- Click Export-to-file button from File menu
- Choose Grouped-by-folder from the drop-down menu
- Click Export-to-file button (with gear icon)
- Determine a txt file name to store folder hierarchy and file list

2. Select the desired folders and files using FileListExporter
- Run FileListExporter
- Select a txt file which is exported from SpaceSniffer
- Determine a filelist file name to store the selected folder and file information
- Select folders and files
- Click Save or Save-As buttons to save current selections
(If you send the saved FileListExporter file to another person, that person can also select or deselect folders and files from the saved status)

3. Export the selected folders and files using FileListExporter
- Run FileListExporter
- Selecet a filelist file which was saved from FileListExporter
- Click Export-for-FastCopy button
- Determine a txt file name to store the selected folder and file list

4. Backup the selected folders and files using FastCopy
- Run FastCopy
- Open the txt file exported from FileListExporter
- Copy all the text in the txt file
- Paste it into the text box next to the Source button in FastCopy.
- Click DestDir button and determine a desetination folder to back up all folders and files.
- Click Execute button
