######################################################################
##	Readme File for developers to upgrade and improve this program	##
##	==============================================================	##
##	This hack provides various methods to show practical usage		##
##	of functions within the Win API. This tool is for educational	##
##	usage only. Don't use this tool to cheat or harm Blizzard		##
##	Entertainment's Terms of Service!								##
######################################################################

1.)	Introducing the folder "Classes"
	-->	The file "BufferPanel.cs" is a file which allows us to draw a filled box and rectangles.
		This gives us a possibility to show the user in which Setting he currently is.
			* BUG: Sometimes, you need to adjust the general width (when there are over 100 settings/ boxes)
			
	--> The file "Pivokes.cs" contains static WinApi methods which allow us to use some basic operations

	--> The file "PlayerInfo.cs" contains a lot information about the user, the map and units.
		The name is not the content. You can simply use this class to find values.
		
	-->	The file "Processes.cs" opens a process and returns an opened handle. 
		It's a little herlperclass for the PlayerInfo.cs

	--> The file "Typo.cs" contains informations about ingame types.
		It's easier to write the actual state than a plain number.

	
	 
