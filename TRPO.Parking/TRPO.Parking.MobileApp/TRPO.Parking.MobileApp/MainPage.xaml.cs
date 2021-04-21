﻿using Autofac;
using System.Collections.Generic;
using TRPO.Parking.Dependencies;
using TRPO.Parking.Logic.Interfaces;
using Xamarin.Forms;

namespace TRPO.Parking.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();

            var logic = DependencyResolver.Container.Resolve<ITestLogicInterface>();

            var entity = logic.GetTestValue().Result;
            var render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetGenders().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetClientTypes().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            entity = logic.GetRentalRenewalTypes().Result;
            render = RenderEntity(entity);
            layout.Children.Add(render);

            Content = layout;
        }

        private StackLayout RenderEntity(IEnumerable<string> entity)
        {
            var layout = new StackLayout
            {
                Margin = new Thickness(10)
            };

            foreach (var s in entity)
            {
                Label label = new Label
                {
                    Text = s
                };
                layout.Children.Add(label);
            }

            return layout;
        }
    }
}