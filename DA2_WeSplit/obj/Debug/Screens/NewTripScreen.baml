   M S B A M L   `   `   `  ����F  BDA2_WeSplit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DA2_WeSplit.ScreensDA2_WeSplit.Screens  5      '    !DA2_WeSplit.Screens.NewTripScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:DA2_WeSplit.Screens     5        � 	Resources  5
       �� 
TargetType �� Property �� Value��%v   '��       �� 5   
   " ��6+   .�5      ��  � ��$ 10��6*   �� 5       � ��$ 10��6'   5      5      .��5      � $��0,10,0,0q�6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��RightToLeft=�62   .+�5      �� -   5         ��Name$ 
ExitButton��5      $��Đóng��6.   $��14(�6=   $��20,0,0,0q�6K   ��5      �� 5      " ��6    .�5      ��  � ��$ 30��67   �� 5       � ��
 �����6;   �� 5       � ��
 �����6;   �� 5        � ��$ 50��66   �� 5!       � ��$ Center=�6D   �� 5"       � �� 5#   "   �� 5$   &    �� 
TargetType" ��66   .R�5%   *   ��  �� CornerRadius$ 8��5&   -   #��z��5'   -   #��z��5(   -   ._�5)   .   � .+�5*   2   �� #��z��5+   5   #��z��5,   5   #��z��5-   5   5/   3   50   /   51   +   	 �� Triggers	 52   *   P� 53   .   
 P� Property
 �@J�IsMouseOver P� Value . . �54   2   ��  � �� �#BBBBBB6a   55   /   P� 56   .   
 � �� . . �57   2   ��  � �� �#AAAAAA6a   58   /   5:   '   5<      5=      5?      �� 5B      -   5        $��Xác nhận��5B      $��14(�6,   $��	10,0,20,0q�6:   $	��Top=�6M   ��5C      �� 5D      " ��6    .�5E      ��  � ��$ 30��67   �� 5F       � ��
 ��� �6;   �� 5G       � ��
 �����6;   �� 5H       � ��$ 80��66   �� 5I       � ��$ Center=�6D   �� 5J       � �� 5K   "   �� 5L   &   " ��66   .R�5M   *   �� $ 8��5N   -   #��z��5O   -   #��z��5P   -   ._�5Q   .   � .+�5R   2   �� #��z��5S   5   #��z��5T   5   #��z��5U   5   5W   3   5X   /   5Y   +   	 5Z   *   P� 5[   .   
 �@J�IsMouseOver . . �5\   2   ��  � �� �#79CDCD6a   5]   /   P� 5^   .   
 � �� . . �5_   2   ��  � �� �#528B8B6a   5`   /   5b   '   5d      5e      5g      5i      5j      � 5l   
   $��1��6   $��	0,10,0,30q�6   .+�5m      �  � ColumnDefinitions 5n      �� 5o      �� 5p      .+�5t      � $��0��6   .+�5u      �� $��0q�6   $ 10��61   
�������$��10,0,5,0q�6[    �� Padding$ 10,0,0,0q�6m   ._�5v      �  5w      �� 5x   "   $��25 �60   �� 5y   "   .+�5{      � $��0��6#   .+�5|   "   �� $��
Thông tin��6,   
��� ���$��18(�6Q   $��Center=�6_   $��SemiBold"�6|   $��0,3,0,0q�6�   6�   5}      � 5~      $��1��6#   .+�5   "   �� $��Hidden=�6/   .��5�   &   �� .+�5�   *   �� .+�5�   .   �� $��Tên chuyến đi��68   $��14(�6M   
����� �$��
0, 5, 0, 1q�6m   �� 5�   .   -   5        $��txtTripName��5�   {   $��30��66   $
��Left=�6B   $	��250��6]   $	��250��6l   
����� �$��14(�6�   $��Center=�6�   .��6�     5�   2   ��%�   '��       �� 5�   6   " ��6<   .�5�   :   ��  � ��
 �����6X   �� 5�   :    �@��CornerRadius$ 3��6Y   5�   7   5�   3   .��6E   5�   /   �� 5�   .   $��Trạng thái��68   $��14(�6J   
����� �$��
0, 5, 0, 1q�6j   �� 5�   .   -   5        $��cbTrangThai��5�   ^   $��Center=�67   $��30��6R   $��16(�6q   
����� �$	��120��6�   $
��Left=�6�   .@�5�   2   ��  �� 
IsSelected . .��6Q   	Đang đi6Z   �� 5�   2   .��6@   Đã đi xong6L     5�   2   ��%�   '��       �� 5�   6   " ��6<   .�5�   :   ��  � ��
 �����6X   �� 5�   :    �@��CornerRadius$ 3��6Y   5�   7   5�   3   5�   /   �� 5�   .   $��Địa điểm��68   $��14(�6H   
����� �$��
0, 5, 0, 1q�6h   �� 5�   .   -   5        $��txtLocation��5�   {   $��30��66   $
��Left=�6B   $	��250��6]   $	��250��6l   
����� �$��14(�6�   $��Center=�6�   .��6�     5�   2   ��%�   '��       �� 5�   6   " ��6<   .�5�   :   ��  � ��
 �����6X   �� 5�   :    �@��CornerRadius$ 3��6Y   5�   7   5�   3   .��6E   5�   /   �� 5�   .   $��Các mốc lộ trình��68   $��14(�6P   
����� �$��
0, 5, 0, 1q�6p   �� 5�   .   $ 
Horizontal=�69   .+�5�   2   �� -   5         ��Name$ txtMilestone��5�      $��30��6:   $
��Left=�6F   $	��250��6a   $	��250��6p   
����� �$��14(�6�   $��Center=�6�   .��6�     5�   6   ��%�   '��       �� 5�   :   " ��6@   .�5�   >   ��  � ��
 �����6\   �� 5�   >    �@��CornerRadius$ 3��6]   5�   ;   5�   7   .��6I   5�   3   �� 5�   2   -   5        $��Thêm��5�   9   $��14(�6H   $��Center=�6W   $��20,0,0,0q�6r   ��5�   6   �� 5�   :   " ��6@   .�5�   >   ��  � ��$ 30��6W   �� 5�   >    � ��
 ��� �6[   �� 5�   >    � ��
 �����6[   �� 5�   >    � ��$ 60��6V   �� 5�   >    � ��$ Center=�6d   �� 5�   >    � �� 5�   B   �� 5�   F   " ��6V   .R�5�   J   �� $ 8��5�   -   #��z��5�   -   #��z��5�   -   ._�5�   N   � .+�5�   R   �� #��z��5�   5   #��z��5�   5   #��z��5�   5   5�   S   5�   O   5�   K   	 5�   J   P� 5�   N   
 �@J�IsMouseOver . . �5�   R   ��  � �� �#79CDCD6�   5�   O   P� 5�   N   
 � �� . . �5�   R   ��  � �� �#528B8B6�   5�   O   5�   G   5�   ?   5�   ;   5�   3   5�   /   �� 5�   .   -   5        $��lbMilestones��5�   �   $	��250��66   $
��Left=�6E   $	��300��6`   
������ $��0,0,0,0q�6�   $��0q�6�   
������ $��Stretch=�6�   ��5�   2   �� 5�   6   .R�5�   :   �� $ 3��6A   ���#eeeeee._�5�   >   � $��1q�6C   .+�5�   B   �� 
��� ���$��0��6`   $��Center=�6�   ��6p   �� *
MocLoTrinh+6�   5�   ?   5�   ;   5�   7   5�   /   �� 5�   .   $ 
Horizontal=�69   .+�5�   2   �� $��Thêm ảnh bìa��6<   $��14(�6P   
����� �$��
0, 5, 0, 1q�6p   �� 5�   2   -	   5        $ 	addAvatar��5�   9   $��+��6L   $��12(�6X   $��Bottom=�6g   $��18,0,0,0q�6�   $	��Top=�6�   ��5�   6   �� 5�   :   " ��6@   .�5�   >   ��  � ��$ 20��6W   �� 5�   >    � ��
 ��� �6[   �� 5�   >    � ��
 �����6[   �� 5�   >    � ��$ 20��6V   �� 5�   >    � ��$ Center=�6d   �� 5�   >    � �� 5�   B   �� 5�   F   " ��6V   .R�5�   J   �� $ 8��5�   M   #��z��5�   M   #��z��5�   M   ._�5�   N   � .+�5�   R   �� #��z��5�   U   #��z��5�   U   #��z��5�   U   5�   S   5�   O   5�   K   	 5�   J   P� 5�   N   
 �@J�IsMouseOver . . �5�   R   ��  � �� �#79CDCD6�   5�   O   P� 5�   N   
 � �� . . �5�   R   ��  � �� �#528B8B6�   5   O   5  G   5  ?   5  ;   5  3   5  /   �� 5
  .   $��1q�65   
�������$ 10��6a   $��80��6s   $	��120��6�   $	��120��6�   $��80��6�   $
��Left=�5  )   ��5  2   �� 5  6   -
   5        
Avatar�� �� BitmapScalingMode$ HighQuality=�5  Q   6�   5  /   �� 5  .   $ 
Horizontal=�69   .+�5  2   �� $��Thêm ảnh chuyến đi��6<   $��14(�6V   
����� �$��
0, 5, 0, 1q�6v   �� 5  2   -   5        $��+��5  9   $��12(�6E   $��Bottom=�6T   $��18,0,0,0q�6o   $	��Top=�6�   ��5  6   �� 5  :   " ��6@   .�5  >   ��  � ��$ 20��6W   �� 5  >    � ��
 ��� �6[   �� 5  >    � ��
 �����6[   �� 5  >    � ��$ 20��6V   �� 5  >    � ��$ Center=�6d   �� 5  >    � �� 5  B   �� 5  F   " ��6V   .R�5  J   �� $ 8��5  M   #��z��5   M   #��z��5!  M   ._�5"  N   � .+�5#  R   �� #��z��5$  U   #��z��5%  U   #��z��5&  U   5'  S   5(  O   5)  K   	 5*  J   P� 5+  N   
 �@J�IsMouseOver . . �5,  R   ��  � �� �#79CDCD6�   5-  O   P� 5.  N   
 � �� . . �5/  R   ��  � �� �#528B8B6�   50  O   52  G   54  ?   55  ;   57  3   58  /   �� 5:  .   -   5        $��lbImages��5:  �   $
��Left=�67   ���#E8E8E8$��0q�6g   
������ $��Disabled=�6�   $��0,0,0,10q�5;  7   $	��380��6I   ��5<  2   �� 5=  6   .R�5>  :   � 5?  7   ��5A  2   �� 5B  6   .R�5I  :   �� $��0q�6A   $ 5��6U   $	��100��6f   $��2,0,2,0q�6r   $��60��6�   $
��Left=�5J  )   ��5K  >   �� 5L  B   $ HighQuality=�6m    �� ImageSource 6M   �� *	HinhAnh+6�   5N  ;   5O  7   5Q  /   �� 5S  .   $!��Thêm mô tả chuyến đi��68   $��14(�6T   
����� �$��
0, 5, 0, 1q�6t   �� 5T  .   -   5        $ txtDescription��5U  *   $��70��5T  6   $
��Left=�6B   $	��350��6]   
����� �$��14(�5U  T   $��50��5V  *    �� TextWrapping$
 Wrap=�69   .��6M     5W  2   ��%�   '��       �� 5X  6   " ��6<   .�5Y  :   ��  � ��
 �����6X   �� 5Z  :    �@��CornerRadius$ 3��6Y   5[  7   5\  3   .��6E   5]  /   5`  +   5b  '   5c  #   5d     5e     5g     5h     � 5i     $��1��6   .+�5j     �� $��0q�6   $ 10��61   
�������$��5,0,10,0q�6[   $ 10,0,0,0q�6m   ._�5k     �  5l     �� 5m  "   $��25 �60   �� 5n  "   .+�5p     � $��0��6#   .+�5q  "   �� $��Khoản thu chi��6,   
��� ���$��18(�6U   $��Center=�6c   $��SemiBold"�6�   $��0,3,0,0q�6�   6�   5r     � 5s     $��1��6#   .+�5t  "   �� $��Hidden=�6/   .��5u  &   �� .+�5v  *   �� $��Các khoản chi��64   $��16(�6I   
�������$��
0, 5, 0, 1q�6i   $��SemiBold"�6}   �� 5w  *   $ 
Horizontal=�65   .+�5x  .   �� .+�5y  2   �� $��Khoản chi��6<   $��14(�6M   
����� �$��
0, 5, 0, 1q�6m   �� 5z  2   -   5        $��txtCostDetail��5{  6   $��30��5z  :   $
��Left=�6F   $	��130��6a   $	��200��6p   
����� �$��14(�6�   $��Center=�6�   .��5{  K     5|  6   ��%�   '��       �� 5}  :   " ��6@   .�5~  >   ��  � ��
 �����6\   �� 5  >    �@��CornerRadius$ 3��6]   5�  ;   5�  7   .��6I   5�  3   5�  /   �� 5�  .   $��10,0,0,0q�69   .+�5�  2   �� $��Số tiền��6<   $��14(�6K   
����� �$��
0, 5, 0, 1q�6k   �� 5�  2   -   5        $ txtCost��5�  a   $��30��5�  :   $
��Left=�6F   $	��130��6a   $	��200��6p   
����� �$��14(�6�   $��Center=�6�   $��10000��5�  r   .��6     5�  6   ��%�   '��       �� 5�  :   " ��6@   .�5�  >   ��  � ��
 �����6\   �� 5�  >    �@��CornerRadius$ 3��6]   5�  ;   5�  7   .��6I   5�  3   5�  /   �� 5�  .   -   5        $��Thêm��5�  5   $��14(�6D   $��Bottom=�6S   $��20,0,0,0q�6n   ��5�  2   �� 5�  6   " ��6<   .�5�  :   ��  � ��$ 30��6S   �� 5�  :    � ��
 ��� �6W   �� 5�  :    � ��
 �����6W   �� 5�  :    � ��$ 60��6R   �� 5�  :    � ��$ Center=�6`   �� 5�  :    � �� 5�  >   �� 5�  B   " ��6R   .R�5�  F   �� $ 8��5�  -   #��z��5�  -   #��z��5�  -   ._�5�  J   � .+�5�  N   �� #��z��5�  5   #��z��5�  5   #��z��5�  5   5�  O   5�  K   5�  G   	 5�  F   P� 5�  J   
 �@J�IsMouseOver . . �5�  N   ��  � �� �#79CDCD6}   5�  K   P� 5�  J   
 � �� . . �5�  N   ��  � �� �#528B8B6}   5�  K   5�  C   5�  ;   5�  7   5�  /   5�  +   �� 5�  *   -   5        $��
lbCostList��5�  .   $	��270��5�  2   $
��Left=�6A   $	��300��6\   $��0,0,0,0q�6l   $��0q�6}   
������ $��Stretch=�6�   
������ ��5�  .   �� 5�  2   .R�5�  6   �� $ 3��6=   ���#eeeeee._�5�  :   � $��1q�6?    5�  >   �� 5�  B   $��* �6S   �� 5�  B   $	��100 �6S   .+�5�  >   �� 
��� ���$��0��6\   ��6l   �� *NDChi+�� 5�  >   
��� ���$��1��6\   ��6l   �� *SoTien+5�  ;   5�  7   5�  3   5�  +   �� 5�  *   $��Các khoản thu��64   $��16(�6I   
�������$��
0, 5, 0, 1q�6i   $��SemiBold"�6}   �� 5�  *   $ 
Horizontal=�65   .+�5�  .   �� .+�5�  2   �� $��Tên thành viên��6<   $��14(�6R   
����� �$��
0, 5, 0, 1q�6r   �� 5�  2   -   5        $ txtMemberName��5�  6   $��30��5�  :   $
��Left=�6F   $	��130��6a   $	��200��6p   
����� �$��14(�6�   $��Center=�6�   .��5�  M     5�  6   ��%�   '��       �� 5�  :   " ��6@   .�5�  >   ��  � ��
 �����6\   �� 5�  >    �@��CornerRadius$ 3��6]   5�  ;   5�  7   .��6I   5�  3   5�  /   �� 5�  .   $��10,0,0,0q�69   .+�5�  2   �� $��Số tiền��6<   $��14(�6K   
����� �$��
0, 5, 0, 1q�6k   �� 5�  2   -   5        $ txtMemberFee��5�  a   $��30��5�  :   $
��Left=�6F   $	��130��6a   $	��200��6p   
����� �$��14(�6�   $��Center=�6�   .��5�  w     5�  6   ��%�   '��       �� 5�  :   " ��6@   .�5�  >   ��  � ��
 �����6\   �� 5�  >    �@��CornerRadius$ 3��6]   5�  ;   5�  7   .��6I   5�  3   5�  /   �� 5�  .   -   5        $��Thêm��5�  5   $��14(�6D   $��Bottom=�6S   $��20,0,0,0q�6n   ��5�  2   �� 5�  6   " ��6<   .�5�  :   ��  � ��$ 30��6S   �� 5�  :    � ��
 ��� �6W   �� 5�  :    � ��
 �����6W   �� 5�  :    � ��$ 60��6R   �� 5�  :    � ��$ Center=�6`   �� 5�  :    � �� 5�  >   �� 5�  B   " ��6R   .R�5�  F   �� $ 8��5�  -   #��z��5�  -   #��z��5�  -   ._�5�  J   � .+�5�  N   �� #��z��5�  5   #��z��5�  5   #��z��5�  5   5�  O   5�  K   5�  G   	 5   F   P� 5  J   
 �@J�IsMouseOver . . �5  N   ��  � �� �#79CDCD6}   5  K   P� 5  J   
 � �� . . �5  N   ��  � �� �#528B8B6}   5  K   5  C   5
  ;   5  7   5  /   5  +   �� 5  *   -   5        $��	lbMembers��5  .   $	��270��5  2   $
��Left=�6A   $	��300��6\   $��0,0,0,0q�6l   $��0q�6}   
������ $��Stretch=�6�   
������ ��5  .   �� 5  2   .R�5  6   �� $ 3��6=   ���#eeeeee._�5  :   � $��1q�6?    5  >   �� 5  B   $��* �6S   �� 5  B   $	��100 �6S   .+�5  >   �� 
��� ���$��0��6\   ��6l   �� *TenThanhVien+�� 5  >   
��� ���$��1��6\   ��6l   �� *SoTien+5  ;   5  7   5  3   5!  +   5"  '   5#  #   5$     5%     5&     5'     5(     5,     5-     5�     