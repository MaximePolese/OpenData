   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5   	   J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5   	   &    WpfApplication1.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  	Metro API��5	   	   $
��Auto��6   $
��Auto��6)    � SizeToContent$ WidthAndHeight=�66    � Icon$&  SIT_TAGPRO_118_TAG-M-size-2x.ico��5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��	Longitude��6-   $��	25 5 5 0 q�6A   $	��Top=�6T   $
��Left=�5      �� 5   
   $��0��6   $��1��6"   $��25��6/   $	��150��6;   
�������$��1q�6Z   $��	25 0 5 25q�5   '   $	��Top=�6:   $
��Left=�6R   ��6   �� *Lon+6R   �� 5   
   $��1��6   $��0��6    $��Latitude��6-   $��5 5 5 0q�6@   $	��Top=�5      $
��Left=�5      �� 5    
   $��1��6   $��1��6"   $��25��6/   $	��150��6;   
�������$��1q�6Z   $��	5 0 5 25 q�5!   '   $	��Top=�6:   $
��Left=�6R   ��6   �� *Lat+6R   �� 5#   
   $��2��6   $��0��6    $��Distance��6-   $��5 5 5 0q�6@   $	��Top=�6Q   $
��Left=�5$      �� 5%   
   $��2��6   $��1��6"   $��25��6/   $	��150��6;   
�������$��1q�6Z   $��5 0 5 25q�5&   (   $	��Top=�6:   $
��Left=�6R   ��6   �� *Dist+6R   �� 5(   
   $��3��6   $��1��6!   $��25��6.   $��SEARCH��6U   $	��100��6f   $��Center=�5)      $��
25 0 25 25q�63   $	��top=�6G   $��Center=�5*      
��� ����5(   :   �� *Search+5*   .   �� 5,   
   $	��500��6   $��Center=�6    $��Visible=�6B   ��. $��0��5.      $��3��6#   $��2��67   $��0q�6h   ��6D   �� *BusStopList+ �� View 5/      �� 50      .P�51      ��  �� Width$	 100��6%   $��Id��6U    �� DisplayMemberBinding 61   �� *id+6U   �� 52      $	 150��6%   $
��Name��6W    61   �� *name+6W   �� 53      $	 100��6%   $��	Longitude��6V    61   �� *lon+6V   �� 54      $	 100��6%   $��Latitude��6V    61   �� *lat+6V   �� 55      $	 125��6%   $
��Zone��6W    61   �� *zone+6W   �� 56      $	 120��6%   $��Connection Lines��61    �� CellTemplate 57      �� 58      .R�59   "   �� ��6/   �� *ConnectionLines+5;      5=      5>      5@      '   !Microsoft.Maps.MapControl.WPF.Map  5B   
   -   5        	  Name$	 myMap��5B      +   %Microsoft.Maps.MapControl.WPF.MapCore
   CredentialsProviderT   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F
 @Au5kaMYJOxpMPXbkFydIfrmaJA9GtoVggg1D1X7AaL6xwkAolNPG17YSYmHcQhnV 6   $��3��5C      $��2��6    $��0 q�6-   $
��Auto��69   $	��500��6G      Center 5D      �� *Center+ �� Mode$ TwoWay=�   	ZoomLevel 5E      �� *Zoom+$ TwoWay=�   Children. 5H      3   -Microsoft.Maps.MapControl.WPF.MapItemsControl  ��6    �� *BusStopArroundMe+��5I      �� 5J      .R�5K      +   %Microsoft.Maps.MapControl.WPF.Pushpin  ���#7FFF00   Location 6$   �� 69   5L      5N        5P      ��6    �� *
MyPosition+��5Q      �� 5R      .R�5S        
���  �� 6$   �� 69   5T      5V        5X      ��6    �� *Line+��5Y      �� 5Z      .R�5[      /   )Microsoft.Maps.MapControl.WPF.MapPolyline  0   *Microsoft.Maps.MapControl.WPF.MapShapeBase   Stroke
 ��  �   StrokeThickness$ 5Q�66      Opacity$	 0.7Q�6`      	Locations 6J   �� 6`   5\      5^      5`      5a      5b      