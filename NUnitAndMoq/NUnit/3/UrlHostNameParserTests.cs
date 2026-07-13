using System;
using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new UrlHostNameParser();
        }

        // ---- Path 1: valid http/https protocol ----
        [TestCase("https://www.google.com/search", "www.google.com")]
        [TestCase("http://www.example.com/path", "www.example.com")]
        [TestCase("https://test.co.in", "test.co.in")]
        public void ParseHostName_ValidUrl_ReturnsCorrectHostName(string url, string expectedHost)
        {
            var result = _parser.ParseHostName(url);
            Assert.That(result, Is.EqualTo(expectedHost));
        }

        // ---- Path 2: invalid protocol ----
        [TestCase("ftp://www.example.com")]
        [TestCase("ws://socket.example.com")]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException(string url)
        {
            Assert.Throws<FormatException>((TestDelegate)(() => _parser.ParseHostName(url)));
        }
    }
}