   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MediaPlayer.UIMediaPlayer.UI  5   	        MediaPlayer.UI.MediaWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MediaPlayer.UI     5   	   -   5          � Title$  Media Player��5   	   $	��576��6   $
��1024��6+    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ 	CanResize=�6]   .��5	      � ���#2b2b2b � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      r� -   5         r�Name$ Element��5      $��Stretch=�5      $��Stretch=�5       r� LoadedBehavior$ Manual=�5      �� 5      -   5         ��Name$ 
CoverImage��5      $��Center=�5      $��Center=�5      $y�	Collapsed=�5      $	��300��5      $	��300��6   $��UniformToFill=�5       J� Opacity$	 0.8Q�5      $��	0,0,0,100q�5       5!      � 5#   
   ���#34495E$	��100��6$   $��1��61    5$      �� 5%      $
��Auto �6    �� 5&      $��* �6    .+�5)      � $��0��6   $
��10,5q�6     � ColumnDefinitions 5*      �� 5+      $
��Auto �6'   �� 5,      $��* �6'   �� 5-      $
��Auto �6'   .+�50      �� -   5        	 ��Name$	 CurrentTimeTextBlock��50      $��00:00:00��51      $��Center=�52      
�������$��0,0,5,0q�54      $��0��55      �� 56      -   5        
 ��Name$
 ProgressBar��56       � Minimum$ 0Q�57       � Value$ 0Q�58       � Maximum$	 100Q�59       �� IsMoveToPointEnabled$
 True��5;      $��Center=�5<      $��Stretch=�5=      $��1��5@       � ToolTip 5B      �� *HoveredTime+�� 5E      -   5        $	 MaxTimeTextBlock��5E      $��00:00:00��5F      $��Center=�5G      
�������$��5,0,0,0q�5I      $��2��6&   5J      � 5L      $
��20,0q�6   $��1��6!    5M      �� 5N      $	��41* �6'   �� 5O      $
��Auto �6'   �� 5P      $	��82* �6'   �� 5Q      $
��Auto �6'   �� 5R      $	��18* �6'   �� 5S      $	��23* �6'   .+�5V      ��  �� Orientation$ 
Horizontal=�6   $��2��66   $��Center=�6F   $��Center=�6c   .+�5W      �� -   5         ��Name$ PreviousButton��5W      $��40��5X      $��40��6$   
������ 
������ .��5\      �� $/��)pack://application:,,,/Icons/previous.png��6    $��Uniform=�5]      $��30��5^      $��30��6'   5_      �� 5a      -   5        $ 
PlayButton��5a      $��50��5b      $��50��6$   
������ 
������ $��	10,0,10,0q�5f      .��5g      �� -	   5        $ PlayButtonImage��5g       $+��%pack://application:,,,/Icons/play.png��5h      $��Uniform=�5i      $��40��5j      $��40��6'   5k      �� 5m      -
   5        $ 
NextButton��5m      $��40��5n      $��40��6$   
������ 
������ .��5r      �� $+��%pack://application:,,,/Icons/next.png��6    $��Uniform=�5s      $��30��5t      $��30��6'   5u      5v      �� 5x      $ 
Horizontal=�6   $��4��66   $��Center=�6F   $��Right=�6a   $��	10,0,10,0q�6}   $��2��6�   .+�5y      �� $-��'pack://application:,,,/Icons/volume.png��6   $��24��5z      $��24��6#   $��0,0,5,0q�5{      �� 5|      -   5        $
 VolumeSlider��5|      $	��100��5}      $ 0Q�5~      $	 100Q�6%   $	 100Q�5      $��Stretch=�5�      $��Center=�5�       �� TickFrequency$ 1Q�5�       �� IsSnapToTickEnabled$ False��5�      69   5�      �� 5�      $��	0,24,43,0q�6   .+�5�      �� -   5        $ FullScreenButton��5�      $��25��5�      $��25��6$   
������ 
������ $��Bottom=�5�      $
��Left=�5�      $��	22,0,0,11q�5�      .��5�      �� -   5        $ FullScreenButtonImage��5�       $-��'pack://application:,,,/Icons/expand.png��6?   $��Uniform=�5�      $��20��5�      $��20��6'   5�      5�      5�      5�      5�      5�      