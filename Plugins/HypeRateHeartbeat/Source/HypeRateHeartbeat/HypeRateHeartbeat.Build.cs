// Copyright Epic Games, Inc. All Rights Reserved.
using UnrealBuildTool;

public class HypeRateHeartbeat : ModuleRules
{
	public HypeRateHeartbeat(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		bEnableUndefinedIdentifierWarnings = false;

		PublicDependencyModuleNames.AddRange(new string[]{
			"Core",
			"WebSockets",
			"Json",
			"JsonUtilities"
		});
			
		
		PrivateDependencyModuleNames.AddRange(new string[]{
			"Core",
			"CoreUObject",
			"Engine"
		});
	}
}
