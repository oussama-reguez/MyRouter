   M S B A M L   `   `   `  ���� C  ?myRouter, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:myRoutermyRouter      myRouter.PingSettings   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:myRouter     -     � 
ResizeMode$  CanMinimize=� � SizeToContent$ Height=�$
��Auto��$	��550��.����  �� Orientation$ Vertical=�.+��� $��10,0,0,0q�$ Vertical=�.+��� $��Ping Settings��   
titleStyle#��[  �� $��Add or remove ip's ��$��	0,-15,0,0q�  info#��[ &   System.Windows.Controls.DataGrid  -     Name$ pingList����. $	��150��$	��500��   AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  $��
-19,0,-8,0q����� *Network.Pings+
 �� Mode$
 TwoWay=�   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Selected+ �� UpdateSourceTrigger$ PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  $
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *Name+  $ 	Ip adress��$ *  �� *Ip+  $ Country��$ *  �� *	Country+  $ Value�� �� *Value+  $ Active�� �� *Active+$ PropertyChanged=��� $��10�� J� Opacity$ 0Q��� $ 
Horizontal=�$��15,0,0,0q�.+��� -   $��
Select All��$��5,0,0,0q�$��80��  
grayButton#��[ $
��Left=��� $��5��$ 0Q��� -   $��Deselect All��$��80��#��[ $
��Left=��� $��5��$ 0Q��� -   $��Remove��$��50��  	redButton#��[ $
��Left=��� $��5��$ 0Q��� -   $	��Add��$��50��  
blueButton#��[ $
��Left=��� $��5��$ 0Q��� -   $��close��$��50��#��[ $
��Left=��� $��20��$ 0Q�