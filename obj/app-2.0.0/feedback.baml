   M S B A M L   `   `   `  ���� C  ?myRouter, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4      WpfApplication4.feedback   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4       � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=�$
��Auto��$
��Auto��.����  �� Orientation$ Vertical=�$��	10,-5,0,0q�$
��Auto��$
��Left=�.+��� -    ��Name$ feedBackDialog��$ Vertical=�$	��350��.+��� $ 
Horizontal=�.+��� -    ��Name$ imgRouterre��$��Resources/feedback.png��$��Center=� J� Opacity$	 100Q�$��40��$��40��$��1�� �� EdgeMode$ Aliased=� �� BitmapScalingMode$
 Fant=��� $��feedback��$��Center=��� $C��=we value your feedback tell us what's you think about the app���� $��10��$ 0Q�� 	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �
 � ColumnDefinitions
 �� $
��Auto ��� $
��Auto �.+��� $��Your name :��$��0���� -    ��Name$
 name��$	��150��$��0��$��1��.����O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib      �� 
TargetType" �� �� 	Resources    CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%p   &	        !� $
 Left=�$ Center=�$
 None=� �� $��10,0,0,0q�$��10(�$��(optional) ��
������� �� Triggers P�  P� Property � �� �� Empty P� Value# Z . ���  �� Property � �� �� Value# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $��10��$��1��$ 0Q��� $��Email          :��$��2���� -   $ email��$	��150��$��2��$��1��.����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%p   &	        !� $
 Left=�$ Center=�$
 None=� �� $��10,0,0,0q�$��10(�$��(optional) ��
������� P�  � ��# Z . ���  � ��# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $��10��$��3��$ 0Q��� $��Description :��$��4���� -   $ description��$
��150 ��$��50��$��4��$��1�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . .����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%y   &	        !� $	 Top=�$
 Left=�$
 None=� �� $��10,2,0,0q�$��10(�$��tell us what you think ��
������� P�  � ��# Z . ���  � ��# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $ 
Horizontal=��� $��5��$ 0Q��� $ 
Horizontal=��� $��5��$ 0Q��� $ 
Horizontal=��� $��10��$ 0 Q��� $ 
Horizontal=�.+��� -   $��Send Feedback��$��40,0,0,0q�$	��100��  orangeButton#��[ $
��Left=��� $��5��$ 0Q��� -   $��close��$��50��  
grayButton#��[ �� $��10��$ 0 Q��� -   $ success��$ Vertical=�$y�	Collapsed=�.+��� $��10��$ 0Q��� $ 
Horizontal=�$��10,0,0,0q�.+��� -	   $ imgRouterree��$��Resources/check.png��$��Center=�$	 100Q�$��32��$��32��$��1��$ Aliased=�$
 Fant=��� $$��Thank you for your feedback ! ��$��Center=��� $��10��$ 0Q��� $ 
Horizontal=�$��Center=�.+��� $��3��$ 0Q��� $��Center=�$��ok��$��80��#��[ $��25���� $��10��$ 0Q�