   M S B A M L   `   `   `  ���� C  ?myRouter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4      WpfApplication4.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication4       � Title$  Window1��$	��450��$	��700�� � 	Resources    restartButton �� BasedOn �� 
TargetType �� Property �� Value  reconnectButton  RouterStyle  statusStyle  
valueStyle  
titleStyle �� 
TargetType��%u  &	        7 �&	 s     7 �&	 �     &	 e    &	 �    &	 e    '�� �    �� 8   " ��.���  � ��$	 120����  � ��$ 30����  � �� �#4598aa��  � ��
 ������� 8   " ��.���  � ��$ 80����  � ��$ 30����  � �� �#06a319��  � ��
 ������� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 20(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#858080�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#b1b1b1�� " ��.���  � ��$ Regular"���  � ��$ Myriad Pro Regular)���  � ��$ 18(���  � �� �#1FA3FF�� " ��.���  � �� �� " ��.R��� #��z��
�������.���  � RowDefinitions �� $��20 ��� $��40 ��� $
��Auto ��� $��20 ��� $	��120 ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $	��200 �.+��� $��1��$��0��#��[ $��   Router Cnet 4850 m���� 	 �� Orientation$	 
Horizontal=�$��2��.+��� 
 J� Opacity$
 0Q�$��20���� $	 Vertical=�.+��� -   $��imgInternet��$��Resources/internet.png��$��70��$��70�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  -   internetEffect��   ShadowDepth$ 0Q�   Color$
 Gray��   
BlurRadius$ 10Q��� $��Internet��#��[ �� $
 0Q�$��20���� $	 Vertical=�.+��� -   $��	imgRouter��$��Resources/router.png�� �� BitmapScalingMode$ HighQuality=�$��70��$��70��   -   routerEffect��$ 0Q�$ #4598aa��$ 10Q��� $��Router��#��[ �� $
 0Q�$��20���� $	 Vertical=�.+��� -   $��imgAdsl��$��Resources/adsl.png��$ HighQuality=�$��70��   -   
adslEffect��$ 0Q�$
 Gray��$ 10Q��� $
��Adsl��#��[ �� $
 0Q�$��20���� $	 Vertical=�.+��� -   $��
imgDevices��$��Resources/device.png��$ HighQuality=�$��70��   $ 0Q�$
 Gray��$ 10Q��� $��Device��#��[ �� $	
 0.5Q�$��3��$��0��$��20q�$��2��$��30,10,-83,9q�$��2��� $��
30,15,70,0q�$��4��$��2��$��3�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $	��150 ��� $
��Auto ��� $
��Auto �.+��� $��Status��$��0��#��[ �� $��Modulation Type��$��1��#��[ �� $��UpStream��$��2��#��[ �� $��
DownStream��$��3��#��[ �� $��0��$��1��#��[ ���� *Router.Status+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��1��#��[ ���� *Router.Modulation+$ OneWay=��� $��2��$��1��#��[ ���� *Router.UpStream+$ OneWay=��� $��3��$��1��#��[ ���� *Router.DownStream+$ OneWay=��� $��	Ip Adress��$��0��$��2��#��[ �� $��Network Interface��$��1��$��2��#��[ �� $��Download��$��2��$��2��#��[ �� $��Upload��$��3��$��2��$��26��$��Bottom=�#��[ �� $��0��$��3��#��[ ���� *Network.InternetIp+$ OneWay=��� $��1��$��3��#��[ ���� *Network.InterfaceName+$ OneWay=��� $��2��$��3��#��[ ���� *Network.Download+$ OneWay=��� $��3��$��3��#��[ ���� *Network.Upload+$ OneWay=��� $	 
Horizontal=�$��6��$��30,38,254,-54q�$��2��.+��� $
 0Q�$��50���� -   $��Restart router��#��[  �� $
 0Q�$��20���� $��
Reconnecta��#��[ �� $��1��$	��170��$	��120��$��1��$��80,0,0,0q�.+���  �� Left$ 32��
 �� Top$ 15��$	��105��$	��168�����#dbedf8$
 1Q�._��  �� $��20 ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $	��200 �.+��� $��
   ping To��$��1���� $��
   Latency��$��2���� $��
   Country��$��3���� $��1��$��1������ *Network.Ping.Ip+$ OneWay=��� $��2��$��1������ *Network.Ping.Value+$ OneWay=��� $��3��$��1������ *Network.Ping.Country+$ OneWay=��� -	   $��imgInterndet��$��Resources/ping.png��$ HighQuality=�$��46��$ 10��$��46��   $ 0Q�$
 Gray��$ 10Q��� -
    ��Name$ button��$��Button��$��1��$
��Left=�$��47,72,0,-56q�$��6��$	��Top=�$��75��