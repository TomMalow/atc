﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Atc.CodeDocumentation.Markdown
{
    internal class MarkdownBuilder
    {
        private readonly StringBuilder sb = new StringBuilder();

        public static string MarkdownCodeQuote(string code)
        {
            return "`" + code + "`";
        }

        public void Append(string text)
        {
            sb.Append(text);
        }

        public void AppendLine()
        {
            sb.AppendLine();
        }

        public void AppendLine(int indentSpaces, string text)
        {
            var sbLocal = new StringBuilder();
            for (int i = 0; i < indentSpaces; i++)
            {
                sbLocal.Append("&nbsp;");
            }

            sb.AppendLine(sbLocal + text);
        }

        public void AppendLine(string text)
        {
            sb.AppendLine(text);
            sb.AppendLine();
        }

        public void Header(int level, string text)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append("#");
            }

            sb.Append(" ");
            sb.AppendLine(text);
        }

        public void HeaderWithCode(int level, string code)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append("#");
            }

            sb.Append(" ");
            CodeQuote(code);
            sb.AppendLine();
        }

        public void HeaderWithLink(int level, string text, string url)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append("#");
            }

            sb.Append(" ");
            Link(text, url);
            sb.AppendLine();
        }

        public void Link(string text, string url)
        {
            sb.Append("[");
            sb.Append(text);
            sb.Append("]");
            sb.Append("(");
            sb.Append(url);
            sb.Append(")");
        }

        public void Image(string altText, string imageUrl)
        {
            sb.Append("!");
            Link(altText, imageUrl);
        }

        public void Code(string language, string code)
        {
            if (code.EndsWith(".", StringComparison.Ordinal))
            {
                code = code.Substring(0, code.Length - 2);
            }

            if (code.EndsWith(Environment.NewLine, StringComparison.Ordinal))
            {
                code = code.Substring(0, code.Length - 2);
            }

            sb.Append("```");
            sb.AppendLine(language);
            sb.AppendLine(code);
            sb.AppendLine("```");
        }

        public void CodeQuote(string code)
        {
            sb.Append("`");
            sb.Append(code);
            sb.Append("`");
        }

        public void Table(string[] headers, List<string[]> items)
        {
            sb.Append("| ");
            foreach (var item in headers)
            {
                sb.Append(item);
                sb.Append(" | ");
            }

            sb.AppendLine();

            sb.Append("| ");
            foreach (var unused in headers)
            {
                sb.Append("---");
                sb.Append(" | ");
            }

            sb.AppendLine();

            foreach (var item in items)
            {
                sb.Append("| ");
                foreach (var item2 in item)
                {
                    sb.Append(item2);
                    sb.Append(" | ");
                }

                sb.AppendLine();
            }

            sb.AppendLine();
        }

        public void List(string text) // nest zero
        {
            sb.Append("- ");
            sb.AppendLine(text);
        }

        public void ListLink(string text, string url) // nest zero
        {
            sb.Append("- ");
            Link(text, url);
            sb.AppendLine();
        }

        public void SubList(TypeComments typeComments)
        {
            string? s = MarkdownHelper.RenderSubList(typeComments);
            if (!string.IsNullOrEmpty(s))
            {
                sb.Append(s);
            }
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}