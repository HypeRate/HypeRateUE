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
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\include\\"
			// ... add public include paths required here ...
		});
				
		
		PrivateIncludePaths.AddRange(new string[] {
			// ... add other private include paths required here ...
		});
		PublicAdditionalLibraries.AddRange(new string[]{
			//"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_random-vc140-mt.lib"
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_atomic-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_chrono-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_container-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_context-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_contract-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_coroutine-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_date_time-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_exception-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_fiber-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_filesystem-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_graph-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_iostreams-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_json-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_locale-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_log-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_log_setup-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_c99-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_c99f-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_c99l-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_tr1-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_tr1f-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_math_tr1l-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_nowide-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_program_options-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_python310-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_random-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_regex-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_serialization-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_stacktrace_basic-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_stacktrace_noop-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_system-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_thread-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_timer-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_type_erasure-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_unit_test_framework-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_wave-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\boost_wserialization-vc140-mt.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\bz2.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\libcrypto.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\libexpat.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\libffi.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\libssl.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\lzma.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\python310.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\sqlite3.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\zlib.lib",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\zstd.lib",

			// openssl
			/*
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\aes.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\applink.c",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\asn1.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\asn1err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\asn1t.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\asn1_mac.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\async.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\asyncerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\bio.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\bioerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\blowfish.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\bn.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\bnerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\buffer.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\buffererr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\camellia.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cast.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cmac.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cms.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cmserr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\comp.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\comperr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\conf.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\conferr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\conf_api.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\crypto.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cryptoerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ct.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\cterr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\des.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\dh.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\dherr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\dsa.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\dsaerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\dtls1.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ebcdic.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ec.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ecdh.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ecdsa.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ecerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\engine.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\engineerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\evp.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\evperr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\e_os2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\hmac.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\idea.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\kdf.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\kdferr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\lhash.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\md2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\md4.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\md5.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\mdc2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\modes.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\objects.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\objectserr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\obj_mac.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ocsp.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ocsperr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\opensslconf.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\opensslv.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ossl_typ.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pem.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pem2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pemerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pkcs12.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pkcs12err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pkcs7.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\pkcs7err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rand.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\randerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rand_drbg.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rc2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rc4.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rc5.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ripemd.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rsa.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\rsaerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\safestack.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\seed.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\sha.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\srp.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\srtp.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ssl.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ssl2.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ssl3.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\sslerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\stack.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\store.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\storeerr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\symhacks.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\tls1.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ts.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\tserr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\txt_db.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\ui.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\uierr.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\whrlpool.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\x509.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\x509err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\x509v3.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\x509v3err.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\x509_vfy.h",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\__DECC_INCLUDE_EPILOGUE.H",
			"C:\\Users\\Max ReDiGermany\\vcpkg\\installed\\x64-windows\\lib\\openssl\\__DECC_INCLUDE_PROLOGUE.H"
			//*/
		});
		//PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "lib", "foo.a"));


		PublicDependencyModuleNames.AddRange(new string[]{
			"Core",
			// ... add other public dependencies that you statically link with here ...
		});
			
		
		PrivateDependencyModuleNames.AddRange(new string[]{
			"Core",
			"CoreUObject",
			"Engine",
			"Slate",
			"InputCore",
			"SlateCore",
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
