   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  C ?myRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4 Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours     WpfApplication4.About   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
Behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  (   "MahApps.Metro.Controls.MetroWindow    ShowMaxRestoreButton  .     ShowCloseButton .    ShowMinButton .     NonActiveWindowTitleBrush
 �����   WindowTitleBrush
 �����   CleanCloseWindowButtonStyle   WindowCloseButtonStyle# �      WindowMinButtonStyle# �    � 
ResizeMode$ NoResize=�$
��Auto��$	��400�� � SizeToContent$ Height=�.  (System.Windows.Interactivity.Interaction	   	Behaviors	 7   1MahApps.Metro.Behaviours.BorderlessWindowBehavior  
 � 	Resources
  �� 
TargetType  MetroWindowButtonStyle �� BasedOn �� Property �� Value �� Triggers P� Property P� Value  
WhiteBrush  restartButton  reconnectButton  RouterStyle  statusStyle  
valueStyle  
titleStyle �� 
TargetType 	 
blueButton 
 windowButton  
grayButton  settingButton  greenButton  	redButton  orangeButton  noConnection 	 title 
 values 
 titles  info 	 error��%!  &	        7  &	 �     7 �&	 +    7 �&	 �    &	     &	 �    &	     '�� �    &		 �    7 �&	
 �    7 �&	     7 �&	 #    7 �&	 �    7 �&	 �    7 �&	 �	    7 �&	 �
    &	 m    &	 �    &	 o    &	 �    &	 �    �� " ��8   .���  � ��
 �   � P�  �@J�IsMouseOver . . ���  � �� �	#FFBFBFBF��  � ��# �  P�  � �� . . ���  � �� �	#FF8D8D8D�� 8   " ��.���  � ��$	 120����  � ��$ 30����  � �� �#4598aa��  � ��
 ������� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �#06a319��  � ��
 ������� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 20(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 19(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#b1b1b1�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#1FA3FF�� " ��.���  � �� �� " ��.R��� #��z��
��������� 8   " ��.���  � ��$	 120����  � ��$ 30����  � �� �	#FF29AFFF��  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FF1D8DD1�� 8   " ��.���  � ��$	 120����  � ��$ 30����  � ��
 �������  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FFCECED4�� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �	#FF9C9C9C��  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FF8B8B8B�� 8   " ��.���  � ��$ 80����  � ��$ 30����  � ��
 ���� ��  � ��
 �   ��� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �	#FF00B800��  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FF009700�� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �	#FFFF4646��  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FFFF2D2D�� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �	#FFF1B761��  � ��
 �������  � �� �� " ��.R��� #��z��
���   �$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �	#FFEEA02E�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � ��
 �������  � ��
 ������� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 12(���  � �� �#1FA3FF�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 14(���  � �� �	#FFA6A6A6�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 14(���  � �� �#1FA3FF�� " ��.���  � ��$ Normal"���  � ��$ Myriad Pro Regular)���  � ��$ 15(���  �@J�Opacity$	 0.5Q���  � �� �#1FA3FF�� " ��.���  � ��$ Normal"���  � ��$ Myriad Pro Regular)���  � ��$ 15(���  � ��
 �  ����  �@J�Opacity$	 0.5Q�.����  �� Orientation$ Vertical=�.+��� $ Vertical=�$��Center=�.+��� -    ��Name$ 
imgRouterr��$��Resources/logo9.png��$��Center=� J� Opacity$	 100Q�$	��155��$	��126��$��1�� �� EdgeMode$ Aliased=� �� BitmapScalingMode$ HighQuality=��� $ Vertical=�$��Center=�$��	0,-12,0,0q�$��Center=�.+��� $��MyRouter Beta��$��Center=�$��20(�$��Center=��� -    ��Name$ version��$��Center=�$��Center=�$��Version���� $��Center=�$��Center=�$��App created by���� $��Center=�$��Center=�$.��(oussama reguez (oussamareguez@gmail.com)���� $ 
Horizontal=�$��Center=�.+��� �� -    ��Name$ facebookLink��$,��&https://www.facebook.com/oussamareguez?� �� TextDecorations$
 None{�.�.��� $��Resources/facebook.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $��5��$ 0Q��� �� -   $ twitterLink��$'��!https://twitter.com/oussamareguea?�$
 None{�.�.��� $��Resources/twitter.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $��10��$ 0Q��� $��Center=�$
��Auto��$
��Auto��$��1q�����  �� Color$ Black�� �� Opacity$	 0.2Q�._��� -    ��Name$ releasePanel��$ Vertical=�$y�	Collapsed=�$��Center=�.+��� $��Release Notes :��$��Center=��� -    ��Name$ releaseNote��$��Center=��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� -   $��Center=�$��Check for update��{�.  #��[	 $	��110��$��25���� $��10��$ 0Q��� -   $��Center=�$��Feedback��$��80��#��[ $��25���� $��5��$ 0Q��� $ Vertical=��� $��5��$ 0Q��� -	   $��Close��$��Center=�#��[ $��80���� $��10��$ 0Q�