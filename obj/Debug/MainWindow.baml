   M S B A M L   `   `   `  ����D  @PUBGAddOn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	    � AllowsTransparency .  � WindowStyle$
 None=�5	   
   
������  � 
ResizeMode$ NoResize=�66    � WindowState$ 	Maximized=�6L    � Topmost . .��5
      � -   5        $��mainGrid��5
      .+�5   
   �� -   5        $��mainMap��5      $��erangel_car.png��6    � LayoutTransform 5      V� 5      .~�5      �� -   5        mainMapScale��5   %   �� 5      -   5        mainMapRotate��5   &   5      5      �� 5   
   -   5        $��timerTxt��5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6$   $��	test text��6M   $��Center=�6^   $��Center=�6{   $��36(�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      T� 	 T� Y$		 180Q�6)   5      5      �� 5   
   -   5        $��	CircleSeq��5      $ Display=�6%   $��	PreCircle��6N   $��Center=�6_   $��Center=�6|   $��36(�6�   $ 0.5,0.5&�6�   z�5       V� 5!      .~�5"      T� $		 210Q�6)   5#      5%      �� 5&   
   -   5        $��plane��5&      

 �� Top$
 0��6    �� Left$ 0��6-   5(      �� 5)   
   -	   5        $	��cnv��5)      ���	#0CF2B3FF$
 0��6�   $ 0��6�   5+      5,      5-      