﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Diagnostics;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.SharpDevelop.Internal.Templates
{
	public class FileDescriptionTemplate
	{
		string name;
		string language;
		string content;
		string buildAction;
		string copyToOutputDirectory;
		string dependentUpon;
		string subType;
		
		public bool IsDependentFile {
			get {
				return !string.IsNullOrEmpty(dependentUpon);
			}
		}
		
		public FileDescriptionTemplate(XmlElement xml)
		{
			name = xml.GetAttribute("name");
			language = xml.GetAttribute("language");
			buildAction = xml.GetAttribute("buildAction");
			copyToOutputDirectory = xml.GetAttribute("copyToOutputDirectory");
			dependentUpon = xml.GetAttribute("dependentUpon");
			subType = xml.GetAttribute("subType");
			content = xml.InnerText;
		}
		
		/// <summary>
		/// Sets MSBuild properties.
		/// </summary>
		public PropertyGroup CreateMSBuildProperties()
		{
			PropertyGroup pg = new PropertyGroup();
			if (!string.IsNullOrEmpty(copyToOutputDirectory)) {
				pg.Set("CopyToOutputDirectory", StringParser.Parse(copyToOutputDirectory));
			}
			if (!string.IsNullOrEmpty(dependentUpon)) {
				pg.Set("DependentUpon", StringParser.Parse(dependentUpon));
			}
			if (!string.IsNullOrEmpty(subType)) {
				pg.Set("SubType", StringParser.Parse(subType));
			}
			return pg;
		}
		
		public FileDescriptionTemplate(string name, string language, string content)
		{
			this.name    = name;
			this.language = language;
			this.content  = content;
		}
		
		public string Name {
			get {
				return name;
			}
		}
		
		public string Language {
			get {
				return language;
			}
		}
		
		public string Content {
			get {
				return content;
			}
		}
		
		public string BuildAction {
			get {
				return buildAction ?? "";
			}
			set {
				buildAction = value;
			}
		}
	}
}
