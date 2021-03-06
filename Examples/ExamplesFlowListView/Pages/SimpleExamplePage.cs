﻿using System;
using Xamarin.Forms;
using DLToolkit.PageFactory;
using Examples.ExamplesFlowListView.PageModels;
using DLToolkit.Forms.Controls;
using System.Collections.Generic;

namespace Examples.ExamplesFlowListView.Pages
{
    public class SimpleExamplePage : ContentPage, IBasePage<SimpleExamplePageModel>
	{
		public SimpleExamplePage()
		{
			Title = "FlowListView Simple Example";

			var flowListView = new FlowListView() {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None,

				FlowColumnsTemplates = new List<FlowColumnTemplateSelector>() {
					// First column definition:
					new FlowColumnSimpleTemplateSelector() { ViewType = typeof(SimpleExampleView) }, 

					// Second column definition:
					new FlowColumnSimpleTemplateSelector() { ViewType = typeof(SimpleExampleView) },

					// Third column definition:
					new FlowColumnSimpleTemplateSelector() { ViewType = typeof(SimpleExampleView) },
				},
			};

			// BINDINGS:

			// FlowListView FlowItemsSource:
			flowListView.SetBinding<SimpleExamplePageModel>(FlowListView.FlowItemsSourceProperty, v => v.Items);

			flowListView.SetBinding<SimpleExamplePageModel>(FlowListView.FlowLastTappedItemProperty, v => v.LastTappedItem);
			flowListView.SetBinding<SimpleExamplePageModel>(FlowListView.FlowItemTappedCommandProperty, v => v.ItemTappedCommand);

			Content = flowListView;
		}

		// View template definitions used for columns:
		class SimpleExampleView : ContentView
		{
			public SimpleExampleView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand;
				VerticalOptions = LayoutOptions.FillAndExpand;

				var label = new Label() {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
				};

				label.SetBinding<SimpleExamplePageModel.SimpleItem>(Label.TextProperty, v => v.Title);

				Content = label;
			}
		}
	}
}


