﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.WpfDesign.Adorners;
using System.Windows;

namespace ICSharpCode.WpfDesign
{
	/// <summary>
	/// Behavior interface implemented by container elements to support resizing
	/// child elements.
	/// </summary>
	public interface IChildResizeSupport
	{
		/// <summary>
		/// Gets if the child element can be resized.
		/// </summary>
		bool CanResizeChild(DesignItem child);
		
		/// <summary>
		/// Gets the placement for the drag frame adorner.
		/// </summary>
		/// <param name="child">The child being dragged</param>
		/// <param name="horizontalChange">The horizontal change - positive=make larger, negative=make smaller</param>
		/// <param name="verticalChange">The vertical change - positive=make larger, negative=make smaller</param>
		/// <param name="horizontal">The orientation of the resize thumb used. This parameter may be used to determine on which side of the element the element grows/shrinks.</param>
		/// <param name="vertical">The orientation of the resize thumb used. This parameter may be used to determine on which side of the element the element grows/shrinks.</param>
		/// <returns>A placement describing the new location of the child being resized.</returns>
		Placement GetPlacement(DesignItem child, double horizontalChange, double verticalChange, HorizontalAlignment horizontal, VerticalAlignment vertical);
		
		/// <summary>
		/// Resizes the child.
		/// </summary>
		/// <param name="child">The child being dragged</param>
		/// <param name="horizontalChange">The horizontal change - positive=make larger, negative=make smaller</param>
		/// <param name="verticalChange">The vertical change - positive=make larger, negative=make smaller</param>
		/// <param name="horizontal">The orientation of the resize thumb used. This parameter may be used to determine on which side of the element the element grows/shrinks.</param>
		/// <param name="vertical">The orientation of the resize thumb used. This parameter may be used to determine on which side of the element the element grows/shrinks.</param>
		/// <returns>A placement describing the new location of the child being resized.</returns>
		void Resize(DesignItem child, double horizontalChange, double verticalChange, HorizontalAlignment horizontal, VerticalAlignment vertical);
	}
}
