   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MediaPlayerMediaPlayer  5   	       MediaPlayer.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MediaPlayer     5   	     � Title$  Media Player��5   	   $	��576��6   $
��1024��6+    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ 	CanResize=�6]   $��Segoe UI)�6t   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��180 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $	��180��6I   ���#2C3E50.+�5      �� $��80��6   �� 5      -   5         ��Name$ 
HomeButton��5      $
��Home��6)   68   �� 5      -   5        $ MusicButton��5      $��Musics��6*   6;   �� 5      -   5        $ VideoButton��5      $��Videos��6*   6;   5      �� 5   
   -   5         ��Name$ MainContent��5      $��1��6.   $��Stretch=�6>   $��Stretch=�6\   ���#ECF0F1.��5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    5      �� 5       $��* �6'   �� 5!      $
��Auto �6'   .+�5$      �� $��
Your Media��6   $
��Left=�6-   $��	29,30,0,0q�6H   $	��Top=�6[   $	��216��6s   $��30(�6   $��0��6�   �� 5&      $��Recently Played��6      
TitleLabel#��[  62   $
��Left=�6V   $��	29,30,0,0q�6q   $	��Top=�6�   $	��136��6�   $��1��6�   �� 5'      -   5         ��Name$ RecentlyPlayedList��5'      $��2��66   $
��Left=�6C   $	��Top=�6^   $��0��6v   $��29,5,0,0q�6�   ��5(      �� 5)      .R�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� $��80��6(   $��50��63   $��0,0,10,0q�6[   ��6?   �� *
CoverArt+6[   �� 5,   "   $��Center=�6F   $��14(�6a   ��6,   �� *
FileName+6a   5-      5.      50      �� 52      $��Your Playlist��6   #��[  60   $
��Left=�6T   $��	29,30,0,0q�6o   $	��Top=�6�   $	��136��6�   $��3��6�   �� 53      -   5        $ PlaylistListBox��53      $��Stretch=�63   $	��Top=�6Q   $��29,5,0,0q�6i   $	��100��6{   $��0��6�   $��4��6�   �� 54      -   5        $ OpenFileButton��54      $��	Open file��61   ���#34495E$��30��6Z   $��	0,32,30,0q�6f   $��1��6y   $��1��6�   $	��Top=�6�   $	��117��6�   	 J� RenderTransformOrigin$	 0.385,0.505&�6�   6�   �� 55      -   5        $ AddPlaylistButton��55      $��1��64   $��Add Playlist��6D   ���#34495E$
��Left=�6p   $��30��6�   $��	0,32,30,0q�6�   $��3��6�   $	��Top=�6�   $	��117��6�   6�   56      57      58      59      