   M S B A M L   `   `   `  ���� C  ?myRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4      WpfApplication4.feedback   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4       � SizeToContent$  WidthAndHeight=� � Title$ feedback��$	��300��$
��Auto��.��� .+���  �� Orientation$ Vertical=�$��Center=�$
��Auto��$
��Left=�.+��� $ 
Horizontal=�.+��� -    ��Name$ imgRouterre��$��Resources/feedback.png��$��Center=� J� Opacity$	 100Q�$��40��$��40��$��1�� �� EdgeMode$ Aliased=� �� BitmapScalingMode$
 Fant=��� $��feedback��$��Center=��� $C��=we value your feedback tell us what's you think about the app���� $��10��$ 0Q��� $ 
Horizontal=�.+��� $��Your name :���� $	��150��.����O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib      �� 
TargetType" �� �� 	Resources    CueBannerBrush	 j� 
AlignmentX
 j� 
AlignmentY j� Stretch !� Visual��%p   &	        !� $
	 Left=�$
 Center=�$
 None=� �� $��10,0,0,0q�$��10(�$��(optional) ��
������� �� Triggers P�  P� Property � �� �� Empty P� Value# Z . ���  �� Property � �� �� Value# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $��5��$ 0Q��� $ 
Horizontal=�.+��� $��Email          :���� $	��150��.����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%p   &	        !� $
	 Left=�$
 Center=�$
 None=� �� $��10,0,0,0q�$��10(�$��(optional) ��
������� P�  � ��# Z . ���  � ��# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $��5��$ 0Q��� $ 
Horizontal=�.+��� $��Description :���� $
��150 ��$��50�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . .����1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��%y   &	        !� $	
 Top=�$
	 Left=�$
 None=� �� $��10,2,0,0q�$��10(�$��tell us what you think ��
������� P�  � ��# Z . ���  � ��# [  P�  � �� Z� . ���  � ��# [  P�  �@J�IsKeyboardFocused . . ���  � ��
 �����.���� $��10��$ 0 Q��� $ 
Horizontal=�.+��� $��Send Feedback��$��40,0,0,0q�$	��100��  orangeButton#��[ $
��Left=��� $��5��$ 0Q��� $��close��$��50��  
grayButton#��[ 