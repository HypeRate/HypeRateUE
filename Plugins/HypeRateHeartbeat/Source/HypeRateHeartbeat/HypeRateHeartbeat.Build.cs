// Copyright Epic Games, Inc. All Rights Reserved.
using UnrealBuildTool;

public class HypeRateHeartbeat : ModuleRules
{
	public HypeRateHeartbeat(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		bEnableUndefinedIdentifierWarnings = false;
		//PublicDefinitions.Add("WITH_MYTHIRDPARTYLIBRARY=1");

		PublicIncludePaths.AddRange(new string[] {
			// "C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\include\\"
			// ... add public include paths required here ...
		});

		PublicDependencyModuleNames.AddRange(new string[]{
			"Core",
			"WebSockets",
			"Json",
			"JsonUtilities"
			// ... add other public dependencies that you statically link with here ...
		});
			
		
		PrivateDependencyModuleNames.AddRange(new string[]{
			"Core",
			"CoreUObject",
			"Engine",
			"Slate",
			"InputCore",
			"SlateCore",
			"OpenSSL"
			//"HTTP",
			//"Json",
			//"OpenSSL",
			//"JsonUtilities",
			// ... add private dependencies that you statically link with here ...	
		});
		
		
		DynamicallyLoadedModuleNames.AddRange(new string[]{
			// ... add any modules that your module loads dynamically here ...
		});

		RuntimeDependencies.Add(
			"$(BinaryOutputDir)\\boost_random-vc143-mt-x64-1_78.dll",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\bin\\boost_random-vc143-mt-x64-1_78.dll"
		);
		/*
		RuntimeDependencies.Add(
			"$(BinaryOutputDir)\\libssl-1_1-x64.dll",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\bin\\libssl-1_1-x64.dll"
		);*/
	}
}
