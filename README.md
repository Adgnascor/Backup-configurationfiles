# Backup-configurationfiles
Fun console application for backing up your configuration files

## The Idea behind this
On my linux machines all the configuration files is added to the .config directory. 
But on my windows machines they are scattered all over the place. There is probably
something already out there that solves this problem. But I thought it could be a fun and 
a good learning experience.

## How the application should work
The plan is that when i'm in a directory where I have a configuration file I 
want to save. I can just run the executable and choose the file I want to save.
And it should create a folder with the application name and the file in it. 

This is stored in a Backup folder at AppData/Local/backup-folder.


## To keep the backup folder updated
I am thinking on either creating some kind of scheduler to copy all the source files with the latest.
Or when you adding a new application to it, it will automatically update the other files. 

Then if you want you can add this folder to your github page, and all your config files is retrievable from anywhere 🐱‍💻
