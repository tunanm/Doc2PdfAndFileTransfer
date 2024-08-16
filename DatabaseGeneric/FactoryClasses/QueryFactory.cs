﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.11.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using System.Linq;
using Doc2PdfApi.EntityClasses;
using Doc2PdfApi.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.AdapterSpecific;
using SD.LLBLGen.Pro.QuerySpec;

namespace Doc2PdfApi.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory : QueryFactoryBase2
	{
		/// <summary>Creates and returns a new EntityQuery for the dboJsonDataSample entity</summary>
		public EntityQuery<dboJsonDataSampleEntity> dboJsonDataSample { get { return Create<dboJsonDataSampleEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the dboPdfSync entity</summary>
		public EntityQuery<dboPdfSyncEntity> dboPdfSync { get { return Create<dboPdfSyncEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the dboSyncTime entity</summary>
		public EntityQuery<dboSyncTimeEntity> dboSyncTime { get { return Create<dboSyncTimeEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the JsonDataSample entity</summary>
		public EntityQuery<JsonDataSampleEntity> JsonDataSample { get { return Create<JsonDataSampleEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the PdfSync entity</summary>
		public EntityQuery<PdfSyncEntity> PdfSync { get { return Create<PdfSyncEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the SyncTime entity</summary>
		public EntityQuery<SyncTimeEntity> SyncTime { get { return Create<SyncTimeEntity>(); } }

		/// <inheritdoc/>
		protected override IElementCreatorCore CreateElementCreator() { return new ElementCreator(); }
 
	}
}