   M S B A M L   `   `   `  ����F  BDA2_WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DA2_WeSplitDA2_WeSplit  5   	       DA2_WeSplit.Dashboard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DA2_WeSplit     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1024��6)    � WindowStyle$
 None=�5	   	    � AllowsTransparency . 
������ $��15(�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� MergedDictionaries �� Source   MenuButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius � ColumnDefinitions
 � Tag �� TextAlignment �� Triggers P� Property P� Value�� 5   
    5      �� 5      $ /Assets/icons.xaml?�6%   %�  &	        7F��� 5      " d�6-   .�5      ��  � ��
	 �����6/   �� 5       � ��$
	 Left=�68   �� 5       � ��$	 Center=�66   �� 5       � ��$	 55��6+   �� 5       � ��$		 200��6*   �� 5       � ��$	 Center=�6=   �� 5       � ��
	 �����6/   �� 5       � ��	 5      �� 5      "
 d�6*   .R�5      �� $ 	10,0,10,0��5    !   #��z��5!   !   #��z��5"   !   ._�5#   "   �  5$   &   �� 5%   *   $��30 �6;   �� 5'   *   .+�5+   &   F� #��z 6+   #��z��5,   +   8��  5-   +   �� 50   &   $��1��51   )   $
 Left=�52   )   #��z��54   )   #��z��55   )   56   '   57   #   58       5:      P� 5;   "    �@J�IsMouseOver . . �5<   &   ��  � ��	 �#F0F0F06C   5=   #   P� 5>   "    �@d�	IsChecked$
 TrueY�6?   . �5?   &   ��  � ��	 �#EEEEEE6C   �� 5@   &    � ��
	 ��� �6C   �� 5A   &    � ��$	 SemiBold"�6C   5B   #   5E      5G      5H      5Z      .��5\      � .+�5]   
   �� 
�������$ 10��5_   	   ._�5a      �  5c      �� 5e      $	��250 �6'   �� 5g      .+�5k      �  � RowDefinitions 5l      �� 5m      -   5        5m   (   �� 5n      �� 5p      $
��auto �6(   �� 5r      �� 5s      .+�5v      �� $��0��5w      $��30(�5x      $��We Split��5y      $��Center=�5z      $��Center=�5{      $��SemiBold"�60   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�5|      
����� �5}      �� 5�      $��Bottom=�5�      $	��200��5�      
�������5�      �� 5�      $��Trưởng nhóm��5�      $��1��5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$	 50��6;   �� 5�   "    � ��	 �#DDDDDD6?   �� 5�   "    � ��$	 SemiBold"�6?   �� 5�   "    � ��
	 �����6?   �� 5�   "    � ��$		 200��6:   �� 5�   "    � ��$	 Center=�6H   �� 5�   "    � ��	 5�   &   �� 5�   *   "
 ��6:   .R�5�   .   �� $ 25��5�   -   #��z��5�   -   #��z��5�   -   ._�5�   2   � .+�5�   6   A� $��45��6>   $��45��6J    �� Stretch$ UniformToFill=�5�   :   
�������$
��Left=�5�   :   $��2��5�   :   $	��2,0q�5�   :   ��5�   :   �� 5�   >    �� ImageSource$  /Assets/Images/Captain.jpg��5�   =    �� BitmapScalingMode$ HighQuality=�5�   =   5�   ?   5�   7   �� 5�   6   #��z��5�   5   #��z��5�   5   #��z��5�   5   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      �� 5�      $��1��5�      $��Bottom=�5�      $	��200��5�      
�������5�      �� 5�      -   5         ��Name$ 	MenuGroup��5�      $	��200��5�      $��2��5�      $
��0,10q�5�      .+�5�      	� -   5        $��AllTripButton��5�       d� 	IsChecked$
 TrueY�5�      #��[  5�        home# [ 5�      $��Tất cả chuyến đi��5�      5�      	� 5�      -   5        $��CurrentTripButton��5�      #��[  5�       	 right# [ 5�      $��	Đang đi��5�      5�      	� 5�      -   5         	�Name$ PassedTripButton��5�      #��[  5�       
 recent# [ 5�      $��Đã hoàn thành��5�      5�      	� 5�      -   5        $��SettingButton��5�      #��[  5�        settings# [ 5�      $��Cài đặt��5�      5�      	� 5�      -   5        $��SupportButton��5�      #��[  5�        support# [ 5�      $��
Hỗ trợ��5�      5�      5�      5�      � 5�      $��1��6   .+�5�      �� $ 	0,10,10,0��5�      ���#E8E8E8._�5�      �  5�      �� 5�   "   $��30 �60   �� 5�   "   .+�5�      � $��0��5�      .+�5�   "   �� 
����� �$ 0,10,0,0��5�      ._�5�   &   �� -   5         �� Orientation$ 
Horizontal=�5�   1   $��30��5�      
������ $	��Top=�5�      $��RightToLeft=�5�      .+�5   *   �� -	   5        $��
ExitButton��5  )   
������ $��30��5  )   $��30��64   $��10,0,0,0q�5  )   $��0q�5  )   .��5  .   �� $��Assets/Icon/exit.png��64   $��16��5  0   $ HighQuality=�5  0   5
  +   �� 5  *   -
   5        $��MaximizeButton��5  )   
������ $��30��5  )   $��30��64   $��0q�5  )   .��5  .   �� $��Assets/Icon/maximize.png��64   $��16��5  0   $ HighQuality=�5  0   5  +   �� 5  *   -   5        $��MinimizeButton��5  )   
������ $��30��5  )   $��30��64   $��0q�5  )   .��5  .   �� $��Assets/Icon/minimize.png��64   $��16��5  0   $ HighQuality=�5   0   5"  +   5$  '   5%  #   5'     � 5)     -   5        $��
MainScreen��5*     $��1��5+     5-     5.     5/     50     51     52     53     55     