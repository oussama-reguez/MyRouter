   M S B A M L   `   `   `  ���� C  ?myRouter, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:myRoutermyRouter       WpfApplication4.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:myRouter     -     � 
ResizeMode$  CanMinimize=�$	��450��$	��700�� � 	Resources    restartButton �� BasedOn �� 
TargetType �� Property �� Value  reconnectButton  RouterStyle  statusStyle  
valueStyle  
titleStyle �� 
TargetType��%u  &	        7 �&	 s     7 �&	 �     &	 e    &	 �    &	 e    '�� �    �� 8   " ��.���  � ��$	 120����  � ��$ 30����  � �� �#4598aa��  � ��
 ������� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �#06a319��  � ��
 ������� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 20(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 19(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#b1b1b1�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#1FA3FF�� " ��.���  � �� �� " ��.R��� #��z��
�������.����  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $ Vertical=�.+��� #��[ $��0,-5,0,0q�$
��Auto��$
��Left=�$��   Router Cnet 4850 m���� $��8�� J� Opacity$ 0Q��� $ 
Horizontal=�.+��� $��10��$ 0Q��� $ 
Horizontal=�.+��� $��25��$ 0Q��� $ Vertical=�$��70��.+��� $��70��.+��� 
	 �� Top$	 0��
 �� Left$
 2��$��Resources/internet.png�� �� BitmapScalingMode$ HighQuality=�$��70��$��70��A� -   $��imgInternet��$	 0��$	 0.8Q�$��Stretch=�$��70��$��70��$��Stretch=�$	��2px�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 2Q����� -   internetEffect�� �� Color$	 Red���� $��Internet��$��Center=�#��[ �� $��10��$ 0Q��� $ Vertical=�$��70��.+��� $��70��.+��� $	 4��$
 2��$��Resources/router.png��$ HighQuality=�$��70��$��70��A� -   $��	imgRouter��$	 0��$	 0.8Q�$��Stretch=�$��70��$��70��$��Stretch=�$	��2px��   $ 2Q����� -   routerEffect��$	 Red���� $��Router��$��Center=�#��[ �� $��10��$ 0Q��� $ Vertical=�$��70��.+��� $��70��.+��� $	 4��$
 2��$��Resources/adsl.png��$ HighQuality=�$��70��$��70��A� -   $��imgAdsl��$	 0��$	 0.8Q�$��Stretch=�$��70��$��70��$��Stretch=�$	��2px��   $ 2Q����� -   
adslEffect��$	 Red���� $
��Adsl��#��[ $��Center=��� $��10��$ 0Q��� $ Vertical=�.+��� $��70��.+��� $	 4��$
 2��$��Resources/device.png��$ HighQuality=�$��70��$��70��A� -   $��	imgDevice��$	 0��$	 0.8Q�$��Stretch=�$��70��$��70��$��Stretch=�$	��2px��   $ 2Q����� $
 Gray���� $ 
Horizontal=�$��Center=�.+��� $��Devices��$��-6,0,0,0q�#��[ �� $��-3,0,0,0q�#��[ ���� *Network.ConnectedDevices+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��10��$ 0Q��� $��1��$	��290��$	��120��$��1��.+��� -	    ��Name$ 
pingBorder��$
 32��$	 15��$	��105��$	��260�����	#FFB3E2FF$ 1Q�._��  � RowDefinitions �� $��20 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $	��200 �.+��� $��   ping To :�� 
 titles#��[ $��1���� $��   Latency :��$��2��#��[ �� $��   Country :��$��3��#��[ �� $��1��$��1�� 
 values#��[ ����   	converter �� 	Converter# [  � DataContext �� *Network.Ping+$ OneWay=��� $��2��$��1��#��[ ���� *Network.Ping.Value+$ OneWay=��� $��3��$��1��#��[ ���� *Network.Ping.Country+$ OneWay=��� -
   $ connectionLost��$
 32��$	 15��$	��105��$	��260��$y�	Collapsed=�
���   �$	 0.5Q�._��� $ 
Horizontal=�$��Center=�.+��� $!��Resources/network_tower.png��$ HighQuality=�$��70���� $��No connection��$��Center=� 	 noConnection#��[	 �� -    
 settingButton#��[
 $��75�� �� Bottom$ 0�� �� Right$ 5��.���� $ 
Horizontal=�.+��� $��Resources/settings.ico��$��20���� 
�������
settings�� -   $��imgInterndet��$��Resources/ping.png��$ HighQuality=�$��40��$
 15��$	 1��$��46�� 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   Color$
 Gray��   
BlurRadius$ 6Q��� $��10��$ 0Q��� $	 0.5Q�$��	35,0,60,0q�$��3��$��0��$��20q�$��2��$��2��� $��	35,10,0,0q�$��4��$��2��$��3�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $	��190 ��� $
��Auto ��� $
��Auto �.+��� $��Status��$��0��#��[ �� $��Modulation Type��$��1��#��[ �� $��UpStream��$��2��#��[ �� $��
DownStream��$��3��#��[ �� $��Wan IP��$��4��#��[ �� $��0��$��1��#��[ ���� *Router.Status+$ OneWay=�$ PropertyChanged=��� $��1��$��1��#��[ ���� *Router.Modulation+$ OneWay=��� $��2��$��1��#��[ ���� *Router.UpStream+$ OneWay=��� $��3��$��1��#��[ ���� *Router.DownStream+$ OneWay=��� $��4��$��1��#��[ ���� *Router.Internet+$ OneWay=��� $��Lan IP��$��0��$��2��#��[ �� $��Network Interface��$��1��$��2��#��[ �� $��Download��$��2��$��2��#��[ �� $��Upload��$��3��$��2��$��Bottom=�#��[ �� $��0��$��3��#��[ ���� *	Router.Ip+$ OneWay=��� $��1��$��3��#��[ ���� *Network.InterfaceName+$ OneWay=��� $��2��$��3��#��[ ���� *Network.Download+$ OneWay=��� $��3��$��3��#��[ ���� *Network.Upload+$ OneWay=��� $��5��$ 0Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $ 0Q�$��50���� -    ��Name$ restart�� � ToolTip$ 	Not shown��$��Restart router��  
blueButton#��[ �� $ 0Q�$��10���� -   $ 	reconnect��$��	Reconnect��  greenButton#��[ �� $ 0Q�$��5���� -   $��About��  orangeButton#��[ �� $ 0Q�$��5���� $��Close��  	redButton#��[ 