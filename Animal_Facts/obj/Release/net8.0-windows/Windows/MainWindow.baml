   M S B A M L   `   `   `  ���� B  >API_hub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:API_hubAPI_hub      API_hub.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:API_hub       � Title$  
MainWindow��$	��500��$	��400��.���  � ColumnDefinitions �� $
��0.1* ��� $��* ��� $
��0.1* � � RowDefinitions �� $
��auto ��� $��3* ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��0.1* �.+��� ���#3DB1A1$��0��$��0��$��10��$��4���� ���#008080$��1��$��1��$��1��$��4��o� $��0��$��3��.@�m� $��_File��$��20(�.@�m� -   $��_Close��$��20(�&   System.Windows.Controls.DataGrid  -   $��ListDataGrid��   SelectionUnit$ FullRow=�$��1��$��1��   SelectionMode$ Single=�   
IsReadOnly$
 True��   AutoGenerateColumns$ False��$��10q�$��20(� � 	Resources    CenteredCellStyle �� 
TargetType	 �� Property
 �� Value��%1   &	        �� " ��.��� 	 � ��$
 Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   Binding_Column��,  &System.Windows.Controls.DataGridColumn   Header$ Search results��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [     Binding �� *name+�� -   $��API_Selection��$��1��$��2��$��20(�$��Center=�$��Center=�$��30��$	��250�� �� SelectedIndex$ 0��$��Center=�.@��� $��Animals��
 � Tag$ 1���� $��Recipes��$ 2���� $��	Cocktails��$ 3���� $��Drinks��$ 4���� -   $��TB_Name��$��5q�$��1��$��20(�$��3���� -   $��Search��$��1��$��10q�$��20(�$��4��