﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.QuerySpec;
using Doc2PdfApi.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses.DTOProjectionHelpers;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Dtos.Persistence
{

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Dtos.DtoClasses.JsonDataSample from the entity model.</summary>
	public static partial class JsonDataSamplePersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToJsonDataSample(System.Linq.IQueryable{Doc2PdfApi.EntityClasses.JsonDataSampleEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToJsonDataSample(ref System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToJsonDataSample(EntityQuery{Doc2PdfApi.EntityClasses.JsonDataSampleEntity}, Doc2PdfApi.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToJsonDataSample(EntityQuery{Doc2PdfApi.EntityClasses.JsonDataSampleEntity}, Doc2PdfApi.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToJsonDataSampleQs(ref System.Linq.Expressions.Expression<Func<Dtos.DtoClasses.JsonDataSample>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static JsonDataSamplePersistence() { }
	
		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.JsonDataSample which instances are projected from the results of the specified baseQuery, which returns Doc2PdfApi.EntityClasses.JsonDataSampleEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Dtos.DtoClasses.JsonDataSample instances</returns>
		public static IQueryable<Dtos.DtoClasses.JsonDataSample> ProjectToJsonDataSample(this IQueryable<Doc2PdfApi.EntityClasses.JsonDataSampleEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.JsonDataSample which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Doc2PdfApi.EntityClasses.JsonDataSampleEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Dtos.DtoClasses.JsonDataSample instances</returns>
		public static DynamicQuery<Dtos.DtoClasses.JsonDataSample> ProjectToJsonDataSample(this EntityQuery<Doc2PdfApi.EntityClasses.JsonDataSampleEntity> baseQuery, Doc2PdfApi.FactoryClasses.QueryFactory qf)
		{
			System.Linq.Expressions.Expression<Func<Dtos.DtoClasses.JsonDataSample>> projectionAdjustments = null;
			GetAdjustmentsForProjectToJsonDataSampleQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ"))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Dtos.DtoClasses.JsonDataSample()
				{
					CreateBy = JsonDataSampleFields.CreateBy.Source("__BQ").ToValue<System.String>(),
					CreateDate = JsonDataSampleFields.CreateDate.Source("__BQ").ToValue<Nullable<System.DateTime>>(),
					FileName = JsonDataSampleFields.FileName.Source("__BQ").ToValue<System.String>(),
					FilePath = JsonDataSampleFields.FilePath.Source("__BQ").ToValue<System.String>(),
					Id = JsonDataSampleFields.Id.Source("__BQ").ToValue<System.String>(),
					JsonData = JsonDataSampleFields.JsonData.Source("__BQ").ToValue<System.String>(),
					UpdateBy = JsonDataSampleFields.UpdateBy.Source("__BQ").ToValue<System.String>(),
					UpdateDate = JsonDataSampleFields.UpdateDate.Source("__BQ").ToValue<Nullable<System.DateTime>>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_JsonDataSample 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.JsonDataSample which instances are projected from the Doc2PdfApi.EntityClasses.JsonDataSampleEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Doc2PdfApi.EntityClasses.JsonDataSampleEntity instance created from the specified entity instance</returns>
		public static Dtos.DtoClasses.JsonDataSample ProjectToJsonDataSample(this Doc2PdfApi.EntityClasses.JsonDataSampleEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample>> CreateProjectionFunc()
		{
			System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample>> mainProjection = p__0 => new Dtos.DtoClasses.JsonDataSample()
			{
				CreateBy = p__0.CreateBy,
				CreateDate = p__0.CreateDate,
				FileName = p__0.FileName,
				FilePath = p__0.FilePath,
				Id = p__0.Id,
				JsonData = p__0.JsonData,
				UpdateBy = p__0.UpdateBy,
				UpdateDate = p__0.UpdateDate,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_JsonDataSample 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.JsonDataSampleEntity, Dtos.DtoClasses.JsonDataSample>> projectionAdjustments = null;
			GetAdjustmentsForProjectToJsonDataSample(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


