   M S B A M L   `   `   `  ���� C  ?myRouter, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4  "    WpfApplication4.updateDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4       � Title$  updateDialog��$
��Auto��$
��Auto�� � SizeToContent$ WidthAndHeight=�.����  �� Orientation$ Vertical=�.+��� -    ��Name$ success��$ Vertical=�$y�	Collapsed=�.+��� $��10�� J� Opacity$ 0Q��� $ 
Horizontal=�$��10,0,0,0q�.+��� -    ��Name$ imgRouterree��$��Resources/check.png��$��Center=�$	 100Q�$��32��$��32��$��1�� �� EdgeMode$ Aliased=� �� BitmapScalingMode$
 Fant=��� $/��)MyRouter 1.00 has successfully installed ��$��Center=��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� -   $��Center=�$��Restart app��$��80��   
blueButton#��[  $��25���� $��3��$ 0Q��� $��Center=�$��close��$��80��  
grayButton#��[ $��25���� $��10��$ 0Q��� -   $ status��$��50��$ Vertical=�$	��300��$y�	Collapsed=�.+��� $��10��$ 0Q��� $ 
Horizontal=�.+��� -    ��Name$ 
statusText��$��10,0,0,0q�$
��Left=��� -   $ 
updateDiag��$ Vertical=�$��5,0,0,0q�$y�	Collapsed=�.+��� $��10��$ 0Q��� $ 
Horizontal=�.+��� -   $ imgRouterre��$��Resources/info.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $.��(a new version of MyRouter is available  ���� $ 
Horizontal=�.+��� $�� what's new in ���� -   $ version���� $��80��.���� -	   	 ��Name$	 releases��$��10,0,0,0q��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� -
   $��Center=�$��update��#��[  $	��110��$��25���� $��10��$ 0Q��� $��Center=�$��Cancel��$��80��  greenButton#��[ $��25���� $��10��$ 0Q��� -   $ noUpdate��$ Vertical=�$	��320��$y�	Collapsed=�.+��� $��10��$ 0Q��� $ 
Horizontal=�$��10,0,0,0q�.+��� -   $ imgRouterreee��$��Resources/check.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $7��1update is not necessary , MyRouter is up to date ��$��Center=��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� $��Center=�$��Restart app��$��80��#��[  $��25���� $��3��$ 0Q��� $��Center=�$��close��$��80��#��[ $��25���� $��10��$ 0Q��� -   $ failed��$ Vertical=�$y�	Collapsed=�.+��� $��10��$ 0Q��� $ 
Horizontal=�$��10,0,0,0q�.+��� $��Resources/cancel.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $/��)could not update the app try again later ��$��Center=��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� -   $��Center=�$��Retry��$��80��#��[  $��25���� $��3��$ 0Q��� $��Center=�$��close��$��80��#��[ $��25���� $��10��$ 0Q�