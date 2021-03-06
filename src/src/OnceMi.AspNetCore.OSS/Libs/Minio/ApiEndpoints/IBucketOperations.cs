﻿/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage,
 * (C) 2017, 2018, 2019 MinIO, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Minio.DataModel;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Minio
{
    public interface IBucketOperations
    {
        /// <summary>
        /// Create a bucket with the given name.
        /// </summary>
        /// <param name="args">MakeBucketArgs Arguments Object that has bucket info like name, location. etc</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        /// <exception cref="InvalidBucketNameException">When bucketName is invalid</exception>
        Task MakeBucketAsync(MakeBucketArgs args, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create a private bucket with the given name.
        /// </summary>
        /// <param name="bucketName">Name of the new bucket</param>
        /// <param name="location">Region</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Task</returns>
        [Obsolete("Use MakeBucketAsync method with MakeBucketArgs object. Refer MakeBucket example code.")]        
        Task MakeBucketAsync(string bucketName, string location = "us-east-1", CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all objects in a bucket
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Task with an iterator lazily populated with objects</returns>
        Task<ListAllMyBucketsResult> ListBucketsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Check if a private bucket with the given name exists.
        /// </summary>
        /// <param name="args">BucketExistsArgs Arguments Object which has bucket identifier information - bucket name, region</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        Task<bool> BucketExistsAsync(BucketExistsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns true if the specified bucketName exists, otherwise returns false.
        /// </summary>
        /// <param name="bucketName">Bucket to test existence of</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Task that returns true if exists and user has access</returns>
        [Obsolete("Use BucketExistsAsync method with BucketExistsArgs object. Refer BucketExists example code.")]
        Task<bool> BucketExistsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove the bucket with the given name.
        /// </summary>
        /// <param name="args">RemoveBucketArgs Arguments Object which has bucket identifier information like bucket name .etc.</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        /// <exception cref="InvalidBucketNameException">When bucketName is invalid</exception>
        [Obsolete("Use RemoveBucketAsync method with RemoveBucketArgs object. Refer RemoveBucket example code.")]
        Task RemoveBucketAsync(RemoveBucketArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove a bucket
        /// </summary>
        /// <param name="bucketName">Name of bucket to remove</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Task</returns>
        Task RemoveBucketAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all objects non-recursively in a bucket with a given prefix, optionally emulating a directory
        /// </summary>
        /// <param name="args">ListObjectsArgs Arguments Object with information like Bucket name, prefix, recursive listing, versioning</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>An observable of items that client can subscribe to</returns>
        IObservable<Item> ListObjectsAsync(ListObjectsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all objects along with versions non-recursively in a bucket with a given prefix, optionally emulating a directory
        /// </summary>
        /// <param name="args">ListObjectsArgs Arguments Object with information like Bucket name, prefix, recursive listing, versioning</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>An observable of items that client can subscribe to</returns>
        IObservable<VersionItem> ListObjectVersionsAsync(ListObjectsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets notification configuration for this bucket
        /// </summary>
        /// <param name="args">GetBucketNotificationsArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task<BucketNotification> GetBucketNotificationsAsync(GetBucketNotificationsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the notification configuration for this bucket
        /// </summary>
        /// <param name="args">SetBucketNotificationsArgs Arguments Object with information like Bucket name, notification object with configuration to set</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task SetBucketNotificationsAsync(SetBucketNotificationsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes all bucket notification configurations stored on the server.
        /// </summary>
        /// <param name="args">RemoveAllBucketNotificationsArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task RemoveAllBucketNotificationsAsync(RemoveAllBucketNotificationsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Subscribes to bucket change notifications (a Minio-only extension)
        /// </summary>
	    /// <param name="args">ListenBucketNotificationsArgs Arguments Object with information like Bucket name, listen events, prefix filter keys, suffix fileter keys</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>An observable of JSON-based notification events</returns>
        IObservable<MinioNotificationRaw> ListenBucketNotificationsAsync(ListenBucketNotificationsArgs args, CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Gets Tagging values set for this bucket
        /// </summary>
        /// <param name="args">GetBucketTagsArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Tagging Object with key-value tag pairs</returns>
        Task<Tagging> GetBucketTagsAsync(GetBucketTagsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the Tagging values for this bucket
        /// </summary>
        /// <param name="args">SetBucketTagsArgs Arguments Object with information like Bucket name, tag key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task SetBucketTagsAsync(SetBucketTagsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes Tagging values stored for the bucket.
        /// </summary>
        /// <param name="args">RemoveBucketTagsArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task RemoveBucketTagsAsync(RemoveBucketTagsArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the Object Lock Configuration on this bucket
        /// </summary>
        /// <param name="args">SetObjectLockConfigurationArgs Arguments Object with information like Bucket name, object lock configuration to set</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task SetObjectLockConfigurationAsync(SetObjectLockConfigurationArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the Object Lock Configuration on this bucket
        /// </summary>
        /// <param name="args">GetObjectLockConfigurationArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>ObjectLockConfiguration object</returns>
        Task<ObjectLockConfiguration> GetObjectLockConfigurationAsync(GetObjectLockConfigurationArgs args, CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Removes the Object Lock Configuration on this bucket
        /// </summary>
        /// <param name="args">RemoveObjectLockConfigurationArgs Arguments Object with information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task RemoveObjectLockConfigurationAsync(RemoveObjectLockConfigurationArgs args, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List all objects non-recursively in a bucket with a given prefix, optionally emulating a directory
        /// </summary>
        /// <param name="bucketName">Bucket to list objects from</param>
        /// <param name="prefix">Filter all incomplete uploads starting with this prefix</param>
        /// <param name="recursive">List incomplete uploads recursively</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>An observable of items that client can subscribe to</returns>
        IObservable<Item> ListObjectsAsync(string bucketName, string prefix = null, bool recursive = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get bucket policy
        /// </summary>
        /// <param name="bucketName">Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Returns Task with bucket policy json as string </returns>
        Task<string> GetPolicyAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the current bucket policy
        /// </summary>
        /// <param name="bucketName">Bucket Name</param>
        /// <param name="policyJson">policy json</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>Returns Task that sets the current bucket policy</returns>
        Task SetPolicyAsync(string bucketName, string policyJson, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the notification configuration set for this bucket
        /// </summary>
        /// <param name="bucketName">Bucket Name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>BucketNotification object populated with the notification subresource</returns>
        Task<BucketNotification> GetBucketNotificationsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets bucket notification configuration
        /// </summary>
        /// <param name="bucketName">Bucket Name</param>
        /// <param name="notification">BucketNotification object</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task SetBucketNotificationsAsync(string bucketName, BucketNotification notification, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove all bucket notifications
        /// </summary>
        /// <param name="bucketName">bucketName</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns></returns>
        Task RemoveAllBucketNotificationsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Subscribes to bucket change notifications (a Minio-only extension)
        /// </summary>
        /// <param name="bucketName">Bucket to get notifications from</param>
        /// <param name="events">Events to listen for</param>
        /// <param name="prefix">Filter keys starting with this prefix</param>
        /// <param name="suffix">Filter keys ending with this suffix</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns>An observable of JSON-based notification events</returns>
        IObservable<MinioNotificationRaw> ListenBucketNotificationsAsync(string bucketName, IList<EventType> events, string prefix = "", string suffix = "", CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get Versioning information on the bucket with given bucket name
        /// </summary>
        /// <param name="args">GetVersioningArgs takes bucket as argument. </param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> GetVersioningResponse with information populated from REST response </returns>
        /// <exception cref="InvalidBucketNameException">When bucketName is invalid</exception>
        Task<VersioningConfiguration> GetVersioningAsync(GetVersioningArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Set Versioning as specified on the bucket with given bucket name
        /// </summary>
        /// <param name="args">SetVersioningArgs Arguments Object with information like Bucket name, Versioning configuration</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        /// <exception cref="InvalidBucketNameException">When bucketName is invalid</exception>
        Task  SetVersioningAsync(SetVersioningArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the Encryption Configuration for the bucket.
        /// </summary>
        /// <param name="args">SetBucketEncryptionArgs Arguments Object with information like Bucket name, encryption config</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        Task SetBucketEncryptionAsync(SetBucketEncryptionArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns the Encryption Configuration for the bucket.
        /// </summary>
        /// <param name="args">GetBucketEncryptionArgs Arguments Object encapsulating information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> An object of type ServerSideEncryptionConfiguration  </returns>
        Task<ServerSideEncryptionConfiguration> GetBucketEncryptionAsync(GetBucketEncryptionArgs args, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes the Encryption Configuration for the bucket.
        /// </summary>
        /// <param name="args">RemoveBucketEncryptionArgs Arguments Object encapsulating information like Bucket name</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation</param>
        /// <returns> Task </returns>
        Task RemoveBucketEncryptionAsync(RemoveBucketEncryptionArgs args, CancellationToken cancellationToken = default(CancellationToken));
    }
}
