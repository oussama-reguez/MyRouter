   M S B A M L   `   `   `  ���� C  ?myRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4      WpfApplication4.Window2   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4       � Title$  Window2��$	��325��$	��300�� � 	Resources  �� 
TargetType   
titleStyle �� Property �� Value  info ��Name  12 �� TargetProperty g� Duration g� FillBehavior	 t� From	
 t� To  TestStoryboard	 W� To W� From  gridAnimation��%f  &	        &	 �     &	     &	 �    &	 �    �� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#1FA3FF�� " ��.���  � ��$ Normal"���  � ��$ Myriad Pro Regular)���  � ��$ 15(���  �@J�Opacity$	 0.5Q���  � �� �#1FA3FF�� $ MyCoolStoryboard��.��t� $ BorderThickness�$ 0:0:1.5D�$ HoldEnd=�$	 
4,60,-2,-8X�$
 
4,24,-2,28X��� .��W� $, &RenderTransform.(TranslateTransform.X)�$	 -50X�W� $ Opacity�$ 0X�$ 1X��� .��W� $ Opacity�$ 1X�$ 0X�$ 0:1:0D�.����  �� Orientation$ Vertical=�$��Center=�$��17,0,17,-31q�.+�� -    �Name$ 
secondGrid��$��Center=� � ColumnDefinitions �� $
��Auto � � RowDefinitions �� $��50 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 
imgRouterr��$��Resources/routerLogo.png��$��Center=� J� Opacity$	 100Q�$	��120��$	��120��$��1�� �� EdgeMode$ Aliased=� �� BitmapScalingMode$
 Fant=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     	Direction$ 0Q�-   routerEffect��   ShadowDepth$ 1Q�   Color$
 Blue��   
BlurRadius$ 5Q�   Opacity$ 1Q��� -    ��Name$
 info��$��info  ��$��2��$��Center=��� -    ��Name$ retry��$��Retry��$��3��$��50��$y�	Collapsed=��� -    ��Name$ authenticationStack��$ Vertical=�$��Center=�$��4��$y�	Collapsed=�.+��� $ Vertical=�.+��� $��Authentication��$��Center=�#��[  �� $!��Enter username and password��$��	0,-15,0,0q�$��Center=�#��[ �� $ Vertical=�$��5��.+��� $ 
Horizontal=�$��Center=�.+��� $��username���� $	��120���� $��4��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� $��	password ���� $	��120���� $��4��$ 0Q��� $��Connect��$��6��$��50��� -   $ 	firstGrid��$��Center=�$ 1Q�$y�	Collapsed=� �� $
��Auto � �� $��90 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $ 	imgRouter��$��Resources/routerLogo.png��$��Center=�$	 100Q�$��83��$	��110��$��0��$ Aliased=�$
 Fant=��� $��Router Setup��$��1��$��Center=�#��[  �� $-��'select your router from the list bellow��$��Center=�$��1��$��0,20,0,0q�#��[ $��2���� $ 
Horizontal=�$��2��$��	26,0,55,0q�$��3��$��Center=�.+��� $��Router Model���� -	    ��Name$ comboBox��$	��135������ .R��� ��`�  �� StringFormat$ {1}:{0}��.1���   �� Path$  	BrandName��� $  Model��� -
   $ button��$��Confirm��$��75��$��Center=�$��4��$��0,18,0,0q�