   M S B A M L   `   `   `  ����D  @Praktih10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Praktih10	Praktih10  5   	       Praktih10.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Praktih10     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         placeHolder �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType ��Name K� ZIndex	 �� Path
 �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%z  &	        7���� 5
   
   " ��6$   8   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
textSource��5   "   
������ $ 2��5   "   ��5   &   �� $
	 Text�
 �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5   "   �� 5      #��z 6&   #��z��6C   $ 1��6m   .��6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � ��
 ���� 6G    5   *   �� 5   .    6:   �� $
	 Text�   *
textSource+  6y   .a�5   2   ��  � ��
 �����6O   5   /   5   '   .��5    1   5!      5"      5#      5%      5&      5'      .��5(      � .+�5)   
   o� $	��Top=�6   .@�5*      m� $��Программа��6   .@�5+      m� -   5         m�Name$ about��5+      $��О программе��6*   6?   m� 5,      -   5        $
 exit��5,      $��
Выход��6)   68   5-      5.      �� 5/   
   -   5         ��Name$ mainListBox��5/      $��20,24,20,110q�6'   �� 50   
   -   5        $ 
inputCount��50      #��[  6&   $ Размер��6K   $
��Left=�6X   $��445,384,0,0q�6s    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��78��6�   $��20��6�   �� 51   
   -   5         ��Name$ createArray��51      $!��Создать массив��6&   $
��Left=�6?   $��560,384,0,0q�6Z   $	��Top=�6o   $��97��6�   $��20��6�   6�   �� 52   
   -   5        $ getNegPosCount��52      $��Рассчитать��6)   $
��Left=�6>   $��691,384,0,0q�6Y   $	��Top=�6n   $��89��6�   6�   �� 53   
   -   5        $ resultOutput��53      $
��Left=�6(   $��440,344,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��345��6�   $��20��6�   55      56      