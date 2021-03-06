// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: cloud.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Cloud {

  /// <summary>Holder for reflection information generated from cloud.proto</summary>
  public static partial class CloudReflection {

    #region Descriptor
    /// <summary>File descriptor for cloud.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CloudReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtjbG91ZC5wcm90bxIFY2xvdWQiNQoQQ21kR2V0U2V0RGV0YWlscxIOCgZV",
            "c2VySUQYASABKAkSEQoJU2VjcmV0S2V5GAIgASgJIlMKEVJlc3BHZXRTZXRE",
            "ZXRhaWxzEigKBlN0YXR1cxgBIAEoDjIYLmNsb3VkLkNsb3VkQ29uZmlnU3Rh",
            "dHVzEhQKDERldmljZVNlY3JldBgCIAEoCSK5AQoSQ2xvdWRDb25maWdQYXls",
            "b2FkEiYKA21zZxgBIAEoDjIZLmNsb3VkLkNsb3VkQ29uZmlnTXNnVHlwZRI2",
            "ChNjbWRfZ2V0X3NldF9kZXRhaWxzGAogASgLMhcuY2xvdWQuQ21kR2V0U2V0",
            "RGV0YWlsc0gAEjgKFHJlc3BfZ2V0X3NldF9kZXRhaWxzGAsgASgLMhguY2xv",
            "dWQuUmVzcEdldFNldERldGFpbHNIAEIJCgdwYXlsb2FkKkQKEUNsb3VkQ29u",
            "ZmlnU3RhdHVzEgsKB1N1Y2Nlc3MQABIQCgxJbnZhbGlkUGFyYW0QARIQCgxJ",
            "bnZhbGlkU3RhdGUQAipJChJDbG91ZENvbmZpZ01zZ1R5cGUSGAoUVHlwZUNt",
            "ZEdldFNldERldGFpbHMQABIZChVUeXBlUmVzcEdldFNldERldGFpbHMQAWIG",
            "cHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Cloud.CloudConfigStatus), typeof(global::Cloud.CloudConfigMsgType), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Cloud.CmdGetSetDetails), global::Cloud.CmdGetSetDetails.Parser, new[]{ "UserID", "SecretKey" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Cloud.RespGetSetDetails), global::Cloud.RespGetSetDetails.Parser, new[]{ "Status", "DeviceSecret" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Cloud.CloudConfigPayload), global::Cloud.CloudConfigPayload.Parser, new[]{ "Msg", "CmdGetSetDetails", "RespGetSetDetails" }, new[]{ "Payload" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum CloudConfigStatus {
    [pbr::OriginalName("Success")] Success = 0,
    [pbr::OriginalName("InvalidParam")] InvalidParam = 1,
    [pbr::OriginalName("InvalidState")] InvalidState = 2,
  }

  public enum CloudConfigMsgType {
    [pbr::OriginalName("TypeCmdGetSetDetails")] TypeCmdGetSetDetails = 0,
    [pbr::OriginalName("TypeRespGetSetDetails")] TypeRespGetSetDetails = 1,
  }

  #endregion

  #region Messages
  public sealed partial class CmdGetSetDetails : pb::IMessage<CmdGetSetDetails>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CmdGetSetDetails> _parser = new pb::MessageParser<CmdGetSetDetails>(() => new CmdGetSetDetails());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CmdGetSetDetails> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cloud.CloudReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CmdGetSetDetails() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CmdGetSetDetails(CmdGetSetDetails other) : this() {
      userID_ = other.userID_;
      secretKey_ = other.secretKey_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CmdGetSetDetails Clone() {
      return new CmdGetSetDetails(this);
    }

    /// <summary>Field number for the "UserID" field.</summary>
    public const int UserIDFieldNumber = 1;
    private string userID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserID {
      get { return userID_; }
      set {
        userID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "SecretKey" field.</summary>
    public const int SecretKeyFieldNumber = 2;
    private string secretKey_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string SecretKey {
      get { return secretKey_; }
      set {
        secretKey_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CmdGetSetDetails);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CmdGetSetDetails other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserID != other.UserID) return false;
      if (SecretKey != other.SecretKey) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (UserID.Length != 0) hash ^= UserID.GetHashCode();
      if (SecretKey.Length != 0) hash ^= SecretKey.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (UserID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserID);
      }
      if (SecretKey.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(SecretKey);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (UserID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(UserID);
      }
      if (SecretKey.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(SecretKey);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (UserID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserID);
      }
      if (SecretKey.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SecretKey);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CmdGetSetDetails other) {
      if (other == null) {
        return;
      }
      if (other.UserID.Length != 0) {
        UserID = other.UserID;
      }
      if (other.SecretKey.Length != 0) {
        SecretKey = other.SecretKey;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            UserID = input.ReadString();
            break;
          }
          case 18: {
            SecretKey = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            UserID = input.ReadString();
            break;
          }
          case 18: {
            SecretKey = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class RespGetSetDetails : pb::IMessage<RespGetSetDetails>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<RespGetSetDetails> _parser = new pb::MessageParser<RespGetSetDetails>(() => new RespGetSetDetails());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<RespGetSetDetails> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cloud.CloudReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RespGetSetDetails() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RespGetSetDetails(RespGetSetDetails other) : this() {
      status_ = other.status_;
      deviceSecret_ = other.deviceSecret_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RespGetSetDetails Clone() {
      return new RespGetSetDetails(this);
    }

    /// <summary>Field number for the "Status" field.</summary>
    public const int StatusFieldNumber = 1;
    private global::Cloud.CloudConfigStatus status_ = global::Cloud.CloudConfigStatus.Success;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Cloud.CloudConfigStatus Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "DeviceSecret" field.</summary>
    public const int DeviceSecretFieldNumber = 2;
    private string deviceSecret_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string DeviceSecret {
      get { return deviceSecret_; }
      set {
        deviceSecret_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as RespGetSetDetails);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(RespGetSetDetails other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      if (DeviceSecret != other.DeviceSecret) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != global::Cloud.CloudConfigStatus.Success) hash ^= Status.GetHashCode();
      if (DeviceSecret.Length != 0) hash ^= DeviceSecret.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Status != global::Cloud.CloudConfigStatus.Success) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Status);
      }
      if (DeviceSecret.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(DeviceSecret);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Status != global::Cloud.CloudConfigStatus.Success) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Status);
      }
      if (DeviceSecret.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(DeviceSecret);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Status != global::Cloud.CloudConfigStatus.Success) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      if (DeviceSecret.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DeviceSecret);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(RespGetSetDetails other) {
      if (other == null) {
        return;
      }
      if (other.Status != global::Cloud.CloudConfigStatus.Success) {
        Status = other.Status;
      }
      if (other.DeviceSecret.Length != 0) {
        DeviceSecret = other.DeviceSecret;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Status = (global::Cloud.CloudConfigStatus) input.ReadEnum();
            break;
          }
          case 18: {
            DeviceSecret = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Status = (global::Cloud.CloudConfigStatus) input.ReadEnum();
            break;
          }
          case 18: {
            DeviceSecret = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class CloudConfigPayload : pb::IMessage<CloudConfigPayload>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CloudConfigPayload> _parser = new pb::MessageParser<CloudConfigPayload>(() => new CloudConfigPayload());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CloudConfigPayload> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cloud.CloudReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudConfigPayload() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudConfigPayload(CloudConfigPayload other) : this() {
      msg_ = other.msg_;
      switch (other.PayloadCase) {
        case PayloadOneofCase.CmdGetSetDetails:
          CmdGetSetDetails = other.CmdGetSetDetails.Clone();
          break;
        case PayloadOneofCase.RespGetSetDetails:
          RespGetSetDetails = other.RespGetSetDetails.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CloudConfigPayload Clone() {
      return new CloudConfigPayload(this);
    }

    /// <summary>Field number for the "msg" field.</summary>
    public const int MsgFieldNumber = 1;
    private global::Cloud.CloudConfigMsgType msg_ = global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Cloud.CloudConfigMsgType Msg {
      get { return msg_; }
      set {
        msg_ = value;
      }
    }

    /// <summary>Field number for the "cmd_get_set_details" field.</summary>
    public const int CmdGetSetDetailsFieldNumber = 10;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Cloud.CmdGetSetDetails CmdGetSetDetails {
      get { return payloadCase_ == PayloadOneofCase.CmdGetSetDetails ? (global::Cloud.CmdGetSetDetails) payload_ : null; }
      set {
        payload_ = value;
        payloadCase_ = value == null ? PayloadOneofCase.None : PayloadOneofCase.CmdGetSetDetails;
      }
    }

    /// <summary>Field number for the "resp_get_set_details" field.</summary>
    public const int RespGetSetDetailsFieldNumber = 11;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Cloud.RespGetSetDetails RespGetSetDetails {
      get { return payloadCase_ == PayloadOneofCase.RespGetSetDetails ? (global::Cloud.RespGetSetDetails) payload_ : null; }
      set {
        payload_ = value;
        payloadCase_ = value == null ? PayloadOneofCase.None : PayloadOneofCase.RespGetSetDetails;
      }
    }

    private object payload_;
    /// <summary>Enum of possible cases for the "payload" oneof.</summary>
    public enum PayloadOneofCase {
      None = 0,
      CmdGetSetDetails = 10,
      RespGetSetDetails = 11,
    }
    private PayloadOneofCase payloadCase_ = PayloadOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PayloadOneofCase PayloadCase {
      get { return payloadCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearPayload() {
      payloadCase_ = PayloadOneofCase.None;
      payload_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CloudConfigPayload);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CloudConfigPayload other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Msg != other.Msg) return false;
      if (!object.Equals(CmdGetSetDetails, other.CmdGetSetDetails)) return false;
      if (!object.Equals(RespGetSetDetails, other.RespGetSetDetails)) return false;
      if (PayloadCase != other.PayloadCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Msg != global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails) hash ^= Msg.GetHashCode();
      if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) hash ^= CmdGetSetDetails.GetHashCode();
      if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) hash ^= RespGetSetDetails.GetHashCode();
      hash ^= (int) payloadCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Msg != global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Msg);
      }
      if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) {
        output.WriteRawTag(82);
        output.WriteMessage(CmdGetSetDetails);
      }
      if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) {
        output.WriteRawTag(90);
        output.WriteMessage(RespGetSetDetails);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Msg != global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Msg);
      }
      if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) {
        output.WriteRawTag(82);
        output.WriteMessage(CmdGetSetDetails);
      }
      if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) {
        output.WriteRawTag(90);
        output.WriteMessage(RespGetSetDetails);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Msg != global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Msg);
      }
      if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CmdGetSetDetails);
      }
      if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RespGetSetDetails);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CloudConfigPayload other) {
      if (other == null) {
        return;
      }
      if (other.Msg != global::Cloud.CloudConfigMsgType.TypeCmdGetSetDetails) {
        Msg = other.Msg;
      }
      switch (other.PayloadCase) {
        case PayloadOneofCase.CmdGetSetDetails:
          if (CmdGetSetDetails == null) {
            CmdGetSetDetails = new global::Cloud.CmdGetSetDetails();
          }
          CmdGetSetDetails.MergeFrom(other.CmdGetSetDetails);
          break;
        case PayloadOneofCase.RespGetSetDetails:
          if (RespGetSetDetails == null) {
            RespGetSetDetails = new global::Cloud.RespGetSetDetails();
          }
          RespGetSetDetails.MergeFrom(other.RespGetSetDetails);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Msg = (global::Cloud.CloudConfigMsgType) input.ReadEnum();
            break;
          }
          case 82: {
            global::Cloud.CmdGetSetDetails subBuilder = new global::Cloud.CmdGetSetDetails();
            if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) {
              subBuilder.MergeFrom(CmdGetSetDetails);
            }
            input.ReadMessage(subBuilder);
            CmdGetSetDetails = subBuilder;
            break;
          }
          case 90: {
            global::Cloud.RespGetSetDetails subBuilder = new global::Cloud.RespGetSetDetails();
            if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) {
              subBuilder.MergeFrom(RespGetSetDetails);
            }
            input.ReadMessage(subBuilder);
            RespGetSetDetails = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Msg = (global::Cloud.CloudConfigMsgType) input.ReadEnum();
            break;
          }
          case 82: {
            global::Cloud.CmdGetSetDetails subBuilder = new global::Cloud.CmdGetSetDetails();
            if (payloadCase_ == PayloadOneofCase.CmdGetSetDetails) {
              subBuilder.MergeFrom(CmdGetSetDetails);
            }
            input.ReadMessage(subBuilder);
            CmdGetSetDetails = subBuilder;
            break;
          }
          case 90: {
            global::Cloud.RespGetSetDetails subBuilder = new global::Cloud.RespGetSetDetails();
            if (payloadCase_ == PayloadOneofCase.RespGetSetDetails) {
              subBuilder.MergeFrom(RespGetSetDetails);
            }
            input.ReadMessage(subBuilder);
            RespGetSetDetails = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
