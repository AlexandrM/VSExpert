using System;
using Extensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;

using EnvDTE;
using EnvDTE80;

//using ASE.VS.Core;

namespace ASEExpertVS2005
{
	/// <summary>
	/// Summary description for AddAllComments.
	/// </summary>
	public class AddAllComments
	{
		public static void DoAction()
		{
			if (IDE.ApplicationObject.Solution == null) 
				return;
			if (IDE.ApplicationObject.Solution.Projects == null) 
				return;

			for(int i_project = 1; i_project <= IDE.ApplicationObject.Solution.Projects.Count; i_project++)
			{
				try
				{
					Project project = IDE.ApplicationObject.Solution.Projects.Item(i_project);

					if (project.ProjectItems == null) 
                        continue;

					for(int i_projectItems = 1; i_projectItems <= project.ProjectItems.Count; i_projectItems++)
					{
						try
						{
							ProjectItem projectItem = project.ProjectItems.Item(i_projectItems);
							
							if (projectItem.FileCodeModel == null) 
                                continue;
							
							if (projectItem.FileCodeModel.CodeElements == null) 
                                continue;

							for(int i_codeElements = 1; i_codeElements <= projectItem.FileCodeModel.CodeElements.Count; i_codeElements++)
							{
								try
								{
									CodeElement codeElement  = projectItem.FileCodeModel.CodeElements.Item(i_codeElements);

									DoComment(codeElement);
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
		}

		private static void DoComment(CodeElement codeElement)
		{
			try
			{
				if (codeElement.Kind == vsCMElement.vsCMElementStruct)
				{
					CodeStruct codeStruct = (CodeStruct) codeElement;
					
					if (codeStruct.Members == null) return;
					
					for(int i_codeStruct = 1; i_codeStruct <= codeStruct.Members.Count; i_codeStruct++)
						DoComment(codeStruct.Members.Item(i_codeStruct));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementInterface)
				{
					CodeInterface codeInterface = (CodeInterface) codeElement;
										
					if (codeInterface.Members == null) return;
										
					for(int i_codeInterfaceMembers = 1; i_codeInterfaceMembers <= codeInterface.Members.Count; i_codeInterfaceMembers++)
						DoComment(codeInterface.Members.Item(i_codeInterfaceMembers));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
				{
					CodeNamespace codeNamespace = (CodeNamespace) codeElement;
					if (codeNamespace.Members == null) return;

					for(int i = 1; i <= codeNamespace.Members.Count; i++)
						DoComment(codeNamespace.Members.Item(i));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementDelegate)
				{
					CodeDelegate codeDelegate = (CodeDelegate) codeElement;

					if (codeDelegate.Comment != "") return;
					
					if (codeDelegate.Access == vsCMAccess.vsCMAccessPrivate)  return;
					
					codeDelegate.Comment = "";
					
					if (codeDelegate.Parameters == null) return;

					for(int i = 1; i <= codeDelegate.Parameters.Count; i++)
						DoComment(codeDelegate.Parameters.Item(i));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementClass)
				{
					CodeClass codeClass = (CodeClass) codeElement;
										
					if (codeClass.Members == null) return;
										
					for(int i_codeClassMembers = 1; i_codeClassMembers <= codeClass.Members.Count; i_codeClassMembers++)
						DoComment(codeClass.Members.Item(i_codeClassMembers));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementEnum)
				{
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementEvent)
				{
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementEventsDeclaration)
				{
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementFunction)
				{
					CodeFunction codeFunction = (CodeFunction) codeElement;

					if (codeFunction.Comment != "") return;
					
					if (codeFunction.Access == vsCMAccess.vsCMAccessPrivate) return;
					
					codeFunction.Comment = "";
					
					if (codeFunction.Parameters == null) return;

					for(int i = 1; i <= codeFunction.Parameters.Count; i++)
						DoComment(codeFunction.Parameters.Item(i));
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementProperty)
				{
					CodeProperty codeProperty = (CodeProperty) codeElement;
					
					if (codeProperty.Comment != "") return;

					if (codeProperty.Access == vsCMAccess.vsCMAccessPrivate)  return;
					
					codeProperty.Comment = "";
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementVariable)
				{
					CodeVariable codeVariable = (CodeVariable) codeElement;

					if (codeVariable.Comment != "") return;

					if (codeVariable.Access == vsCMAccess.vsCMAccessPrivate) return;
					
					codeVariable.Comment = "";
				}
				else if (codeElement.Kind == vsCMElement.vsCMElementParameter)
				{
					CodeParameter codeParameter = (CodeParameter) codeElement;

					if (codeParameter.DocComment != "") return;

				}
			}
			catch
			{
			}
		}
	}
}
