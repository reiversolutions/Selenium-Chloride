using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using LINQtoPOML;

namespace Selenium_Chloride
{
    public interface IBrowser
    {
        IWebDriver IWebDriver { get; }
        List<PageObjectFile> Pomls { get; }

        string Title { get; }

        void NavigateTo(string url);
        void Close();
        void Quit();

        ButtonElement CreateButton(string name);
        CheckboxElement CreateCheckbox(string name);
        ImageElement CreateImage(string name);
        LabelElement CreateLabel(string name);
        LinkElement CreateLink(string name);
        PageElement CreateElement(string name);
        RadioElement CreateRadio(string name);
        SelectElement CreateSlect(string name);
        TableElement CreateTable(string name);
        TextElement CreateText(string name);
    }
}