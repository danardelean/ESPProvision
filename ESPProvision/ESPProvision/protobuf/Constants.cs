// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: constants.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Espressif {

  /// <summary>Holder for reflection information generated from constants.proto</summary>
  public static partial class ConstantsReflection {

    #region Descriptor
    /// <summary>File descriptor for constants.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConstantsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9jb25zdGFudHMucHJvdG8SCWVzcHJlc3NpZiqfAQoGU3RhdHVzEgsKB1N1",
            "Y2Nlc3MQABIUChBJbnZhbGlkU2VjU2NoZW1lEAESEAoMSW52YWxpZFByb3Rv",
            "EAISEwoPVG9vTWFueVNlc3Npb25zEAMSEwoPSW52YWxpZEFyZ3VtZW50EAQS",
            "EQoNSW50ZXJuYWxFcnJvchAFEg8KC0NyeXB0b0Vycm9yEAYSEgoOSW52YWxp",
            "ZFNlc3Npb24QB2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Espressif.Status), }, null, null));
    }
    #endregion

  }
  #region Enums
  public enum Status {
    [pbr::OriginalName("Success")] Success = 0,
    [pbr::OriginalName("InvalidSecScheme")] InvalidSecScheme = 1,
    [pbr::OriginalName("InvalidProto")] InvalidProto = 2,
    [pbr::OriginalName("TooManySessions")] TooManySessions = 3,
    [pbr::OriginalName("InvalidArgument")] InvalidArgument = 4,
    [pbr::OriginalName("InternalError")] InternalError = 5,
    [pbr::OriginalName("CryptoError")] CryptoError = 6,
    [pbr::OriginalName("InvalidSession")] InvalidSession = 7,
  }

  #endregion

}

#endregion Designer generated code