﻿#pragma checksum "d:\Users\User\Documents\Visual Studio 2015\Projects\Client_trivia Aluma Gelbard\Client_trivia Aluma Gelbard\Pages\game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC55ABECF9A7D5F0D6E9854590B61EDB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client_trivia_Aluma_Gelbard.Pages
{
    partial class game : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Grid element1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 10 "..\..\..\Pages\game.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element1).Loaded += this.Grid_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.question = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.answer1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 18 "..\..\..\Pages\game.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.answer1).Tapped += this.answer1_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    this.answer2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 19 "..\..\..\Pages\game.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.answer2).Tapped += this.answer2_Tapped;
                    #line default
                }
                break;
            case 5:
                {
                    this.answer3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 20 "..\..\..\Pages\game.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.answer3).Tapped += this.answer3_Tapped;
                    #line default
                }
                break;
            case 6:
                {
                    this.answer4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 21 "..\..\..\Pages\game.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.answer4).Tapped += this.answer4_Tapped;
                    #line default
                }
                break;
            case 7:
                {
                    this.timer = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.amount = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

