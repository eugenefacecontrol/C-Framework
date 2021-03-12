using System;
using MyFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyFramework.Pages.SalesForce
{
    public class SalesForceUserPage : BasePage
    {
        private By hoverBy = By.XPath("//*[local-name() = 'html']/*[local-name() = 'body']/*[local-name() = 'div'][contains(@class,'desktop') and contains(@class,'container') and contains(@class,'forceStyle') and contains(@class,'oneOne') and contains(@class,'navexDesktopLayoutContainer') and contains(@class,'lafAppLayoutHost') and contains(@class,'forceAccess') and contains(@class,'tablet')]/*[local-name() = 'div'][@class='viewport']/*[local-name() = 'section']/*[local-name() = 'div'][contains(@class,'none') and contains(@class,'navexStandardManager')]/*[local-name() = 'div'][contains(@class,'fullheight') and contains(@class,'center') and contains(@class,'oneCenterStage') and contains(@class,'mainContentMark')]/*[local-name() = 'div'][@class='maincontent']/*[local-name() = 'div'][contains(@class,'contentArea') and contains(@class,'fullheight')]/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div']//*[local-name() = 'div']//*[local-name() = 'one-record-home-flexipage2']//*[local-name() = 'forcegenerated-adgrollup_component___forcegenerated__flexipage_recordpage___sfa__account_rec_l___account___view']//*[local-name() = 'forcegenerated-flexipage_account_rec_l_account__view_js']//*[local-name() = 'record_flexipage-record-page-decorator']/*[local-name() = 'div'][@class='record-page-decorator']/*[local-name() = 'slot']/*[local-name() = 'flexipage-record-home-template-desktop2']/*[local-name() = 'div']/*[local-name() = 'div'][contains(@class,'slds-grid') and contains(@class,'slds-wrap') and contains(@class,'slds-col') and contains(@class,'slds-size_1-of-1') and contains(@class,'row') and contains(@class,'row-main')]/*[local-name() = 'div'][contains(@class,'slds-size_1-of-1') and contains(@class,'slds-medium-size_8-of-12') and contains(@class,'slds-large-size_8-of-12') and contains(@class,'column') and contains(@class,'region-main')]/*[local-name() = 'slot']/*[local-name() = 'slot']/*[local-name() = 'flexipage-component2']/*[local-name() = 'slot']/*[local-name() = 'flexipage-tabset2']/*[local-name() = 'div']/*[local-name() = 'lightning-tabset']/*[local-name() = 'div']/*[local-name() = 'slot']/*[local-name() = 'slot']/*[local-name() = 'slot']/*[local-name() = 'flexipage-tab2'][@role='tabpanel' and @id='tab-3']/*[local-name() = 'slot']/*[local-name() = 'flexipage-component2'][@data-component-id='force_relatedListContainer']//*[local-name() = 'slot']//*[local-name() = 'flexipage-aura-wrapper']/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div'][1]/*[local-name() = 'article']/*[local-name() = 'div'][2]/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'div']/*[local-name() = 'ul']/*[local-name() = 'li']/*[local-name() = 'div'][2]/*[local-name() = 'h3']/*[local-name() = 'div']/*[local-name() = 'a']");

        public void HoverName()
        {
            var hoverByElement = Driver.FindElement(hoverBy);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(hoverByElement).Perform();

            //a[0].Click();
        }
    }
}
