﻿using System;
using System.IO;
using JiebaNet.Analyser;
using JiebaNet.Segmenter.PosSeg;
using NUnit.Framework;

namespace JiebaNet.Segmenter.Tests
{
    [TestFixture]
    public class TestTfidfExtractor
    {
        private string[] GetTestSentences()
        {
            return File.ReadAllLines(@"Cases\jieba_test.txt");
        }

        private string GetFileContents(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        [TestCase]
        public void TestExtractTags()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article.txt");
            var result = tfidf.ExtractTags(text);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }

        [TestCase]
        public void TestExtractTagsWithWeights()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article.txt");
            var result = tfidf.ExtractTagsWithWeight(text);
            foreach (var tag in result)
            {
                Console.WriteLine("({0}, {1})", tag.Word, tag.Weight);
            }
        }

        [TestCase]
        public void TestExtractSportsTags()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article_sports.txt");
            var result = tfidf.ExtractTags(text);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }

        [TestCase]
        public void TestSetStopWords()
        {
            var tfidf = new TfidfExtractor();
            tfidf.SetStopWords(@"Resources\stop_words_test.txt");
            var text = GetFileContents(@"Resources\article_sports.txt");
            var result = tfidf.ExtractTags(text, 30);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }

        [TestCase]
        public void TestExtractSportsTagsSocialNews()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article_social.txt");
            var result = tfidf.ExtractTags(text, 30);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }

        [TestCase]
        public void TestExtractTagsWithPos()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article_social.txt");
            var result = tfidf.ExtractTags(text, 30, Constants.NounAndVerbPos);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }

        [TestCase]
        public void TestExtractIdioms()
        {
            var tfidf = new TfidfExtractor();
            var text = GetFileContents(@"Resources\article_social.txt");
            var result = tfidf.ExtractTags(text, 50, Constants.IdiomPos);
            foreach (var tag in result)
            {
                Console.WriteLine(tag);
            }
        }
    }
}