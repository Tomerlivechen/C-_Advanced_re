   M S B A M L   `   `   `  ���� I  EStore_Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Store_DatabaseStore_Database       Store_Database.IndexWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:Store_Database       � Icon$4  .pack://application:,,,/Resources/Indexicon.ico�� � Title$ 
MainWindow��$	��500��$	��700��.���  � ColumnDefinitions �� $��0.05* ��� �� $��0.05* � � RowDefinitions �� $
��auto ��� $
��auto ��� $��3* ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��0.1* �.+��� ���#3DB1A1$��0��$��0��$��8��$��3���� ���#008080$��1��$��1��$��5��o� $��0��$��3��.@�m� $��_File��$��20(�.@�m� -   $��Change _API Address��$��20(�m� -   $��Change _Manager Passcode��$��20(�m� -   $��Veiw _Workers��$��20(�m� -   $��_Close��$��20(��� $��1��$��1��$��Store Invetory��$��26(�$��Center=�$��Heavy"�&   System.Windows.Controls.DataGrid  -   $��resultsDataGrid��$��1��$��2��$��1��   AutoGenerateColumns$
 True��$��5q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly$
 True���� $��3��$��1��$��5q� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��
Add_Button��$��30��$	��200��$	��Add��$��21(�$��5q��� -   $��Delete_Button��$��30��$	��200��$��Delete��$��21(�$��5q��� -   $��Load_Button��$��30��$	��200��$
��Load��$��21(�$��5q��� $��4��$��1��$��4q�$ 
Horizontal=�$��Center=�.+��� $ Vertical=�.+��� $��Main Category��$��15(�$��Center=��� -	   $��Catagories1�� �� SelectedIndex$ 0��$��18(�$��30��$	��200��$��5q�.@��� $��Main Category���� $ Vertical=�.+��� $��Secondery Category��$��15(�$��Center=��� -
   $��Catagories2��$ 0��$��18(�$��30��$	��200��$��5q�.@��� $��Secondery Category���� $ Vertical=�.+��� -   $��Filter_Button��$��30��$	��200��$��Filter by name��$��21(�$��5q��� -   $��Search��$��18(�$��30��$	��200��$��5q��� $��5��$��1��$��5q�$ 
Horizontal=�$��Center=�.+��� -   $��Edit_Button��$��30��$	��200��$
��Edit��$��21(�$��5q��� -   $��Undermin_Button��$��30��$	��200��$��UnderMin��$��21(�$��5q��� -   $��Report_Button��$��30��$	��200��$��Print Report��$��21(�$��5q�