   M S B A M L   `   `   `  ����K  GcomputingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:computingProjectcomputingProject  5   	   )    #computingProject.breakevenPointCalc   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  6@   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:computingProject  5   	   $	��370��5   	   $��442.071��5	   	     � Title$7  1Break-even point calculator and chart illustrator��5
   	    � 
ResizeMode$ CanMinimize=�6C    � DataContext 5      $   computingProject.MainViewModel  5   
   .��5      � $��0,0,-1,0q�6   $
��Left=�6   $	��349��68   .+�5   
   �� -   5         ��Name$ copyCostsButton��5      $��134,10,10,0q�6*   $	��Top=�6?   $��51��6u   .��5      �� $
��Wrap=�6   Copy costs from Startup Calc6J   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ costGrid��5      $
��Left=�6%   $��	10,38,0,0q�6@   $	��Top=�6S   $	��251��6k   $	��119��6x      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Name of cost��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Name+  5      $
 Cost��6%    63   �� *Cost+  5      $ ID��6%    61   �� *ID+5      �� 5   
   -   5        	 ��Name$	 pricePerUnitBox��5      $��23��6+   $��264,66,10,0q�67   
 �� TextWrapping$

 Wrap=�6L   $	��Top=�6`   $��0��6x   �� 5   
   -   5        $	 variableCostPerUnitBox��5      $��23��62   $��264,94,10,0q�6>   $

 Wrap=�6S   $	��Top=�6g   $��0��6   �� 5   
   -   5        $	 costNameBox��5      $
��Left=�6'   $��20��6B   $��
10,294,0,0q�6N   $

 Wrap=�6b   $��	Cost name��6v   $	��Top=�6�   $��81��6�   �� 5   
   -   5        $	 costBox��5      $
��Left=�6#   $��20��6>   $��
91,294,0,0q�6J   $

 Wrap=�6^   $
��0.00��6r   $	��Top=�6~   $��38��6�   �� 5   
   -   5        $ 	buttonAdd��5      $	��Add��6$   $
��Left=�62   $��
10,319,0,0q�6M   $	��Top=�6a   $	��119��6y   6�   �� 5   
   -   5        $ buttonRemove��5      $��Remove selected items��6'   $
��Left=�6G   $��
10,344,0,0q�6b   $	��Top=�6v   $	��119��6�   $��10(�6�   $��20��6�   6�   �� 5    
   -	   5         ��Name$ salesPriceLabel��5       $��Sales price per unit:��6)   $
��Left=�6I   $��
134,66,0,0q�6d   $	��Top=�6x   $��28��6�   $	��115��6�   �� 5!   
   -
   5        $ variableCostLabel��5!      $��Variable cost per unit:��6+   $
��Left=�6M   $��
134,94,0,0q�6h   $	��Top=�6|   $��28��6�   $	��125��6�   �� 5"   
   $��134,127,10,0q�6   
���   �$��1q�6;   $��52��6O   $	��Top=�6[   ._�5#      � .+�5$      �� -   5        $	 	resultBox��5$      $��Center=�6-   $��23��6J   $��0,23,0,0q�6V   $

 Wrap=�6h   $	��Top=�6|   $	��205��6�   �� 5%      -   5        $ resultLabel��5%      $��Result��6-   $
��Left=�6>   $��Center=�6Y   $	��Top=�6}   $��23��6�   $	��210��6�   5&      5'      �� 5(   
   -   5        $ label��5(      $��Fixed cost table��6   $
��Left=�6:   $��Center=�6U   $��	10,10,0,0q�6y   $	��Top=�6�   $	��119��6�   $
��Bold"�6�   �� 5)   
   -   5        $ calculateButton��5)      $��	Calculate��6*   $��134,184,10,0q�6>   $	��Top=�6T   6l     OxyPlot.Wpf.PlotView  5*   
   -   5          Name$ Graph��5*   G   $��344,10,-555,10q�6/      Model 6   �� *model+6G   � 5+   
   $
��Left=�6   $��35��6*   $��134,209,0,0q�66   $	��Top=�6K   $	��205��6c   .+�5,      �� -   5         ��Name$ checkBox��5,      $��
Show graph��6)   $
��Left=�6>   $��	58,10,0,0q�6Y   $��89��6�   $��15��6�   $	��Top=�6�   5-      �� 5.   
   -   5        $	 
unitNumBox��5.      $
��Left=�6&   $��23��6A   $��227,249,0,0q�6M   $

 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��112��6�   �� 5/   
   -   5        $ label1��5/      $��Num. of units: ��6    $
��Left=�6:   $��23��6U   $��134,249,0,0q�6a   $	��Top=�6v   $��88��6�   50      51      