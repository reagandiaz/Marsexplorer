using Marsexplorer.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System;

namespace Marsexplorer.Test
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void Map00()
        {
            var map = new Map(0, 0);
            string[] expected = { "1", "0", "0" };
            string[] actual = { Convert.ToString(map.Axes.Count), Convert.ToString(map.Axes[0].X), Convert.ToString(map.Axes[0].Ranges[0].Min) };
            Assert.AreEqual(string.Join(',', expected), string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void Map102()
        {
            var map = new Map(10, 2);
            string[] expected = { "1", "10", "2" };
            string[] actual = { Convert.ToString(map.Axes.Count), Convert.ToString(map.Axes[0].X), Convert.ToString(map.Axes[0].Ranges[0].Min) };
            Assert.AreEqual(string.Join(',', expected), string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void E1()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 1, y = 0 };
            map.AddCoordinate(p2);
            string[] expected = { "2", "0", "1", "1", "2", "0:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[1].X),
                Convert.ToString(map.Axes[1].Ranges.Explored()),
                Convert.ToString(map.Explored()),
                Convert.ToString(map.Axes[1].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void E2()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 2, y = 0 };
            map.AddCoordinate(p2);
            string[] expected = { "3", "0", "2", "1", "3", "0:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[2].X),
                Convert.ToString(map.Axes[2].Ranges.Explored()),
                Convert.ToString(map.Explored()),
                Convert.ToString(map.Axes[2].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void W1()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = -1, y = 0 };
            map.AddCoordinate(p2);
            string[] expected = { "2", "-1", "0", "1", "2", "0:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[1].X),
                Convert.ToString(map.Axes[1].Ranges.Explored()),
                Convert.ToString(map.Explored()),
                Convert.ToString(map.Axes[1].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void W2()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = -2, y = 0 };
            map.AddCoordinate(p2);
            string[] expected = { "3", "-2", "0", "1", "3", "0:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[2].X),
                Convert.ToString(map.Axes[2].Ranges.Explored()),
                Convert.ToString(map.Explored()),
                Convert.ToString(map.Axes[2].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }


        [TestMethod]
        public void N1()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 0, y = 1 };
            map.AddCoordinate(p2);
            string[] expected = { "1", "0", "1", "2", "0:1" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[0].Ranges.Count),
                Convert.ToString(map.Axes[0].Ranges.Explored()),
                Convert.ToString(map.Axes[0].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void N2()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 0, y = 2 };
            map.AddCoordinate(p2);
            string[] expected = { "1", "0", "1", "3", "0:2" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[0].Ranges.Count),
                Convert.ToString(map.Axes[0].Ranges.Explored()),
                Convert.ToString(map.Axes[0].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }


        [TestMethod]
        public void S1()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 0, y = -1 };
            map.AddCoordinate(p2);
            string[] expected = { "1", "0", "1", "2", "-1:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[0].Ranges.Count),
                Convert.ToString(map.Axes[0].Ranges.Explored()),
                Convert.ToString(map.Axes[0].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }

        [TestMethod]
        public void S2()
        {
            var map = new Map(0, 0);
            Coordinates p2 = new Coordinates() { x = 0, y = -2 };
            map.AddCoordinate(p2);
            string[] expected = { "1", "0", "1", "3", "-2:0" };
            string[] actual = {
                Convert.ToString(map.Axes.Count),
                Convert.ToString(map.Axes[0].X),
                Convert.ToString(map.Axes[0].Ranges.Count),
                Convert.ToString(map.Axes[0].Ranges.Explored()),
                Convert.ToString(map.Axes[0].Ranges[0])};
            Assert.AreEqual(
                string.Join(',', expected),
                string.Join(',', actual), "Hey!");
        }
    }
}