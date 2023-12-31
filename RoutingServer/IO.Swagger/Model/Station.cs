/* 
 * JcDecaux
 *
 * JcDecaux API
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;
namespace IO.Swagger.Model
{
    /// <summary>
    /// Station
    /// </summary>
    [DataContract]
        public partial class Station :  IEquatable<Station>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Station" /> class.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="contractName">contractName.</param>
        /// <param name="name">name.</param>
        /// <param name="address">address.</param>
        /// <param name="position">position.</param>
        /// <param name="banking">banking.</param>
        /// <param name="bonus">bonus.</param>
        /// <param name="bikeStands">bikeStands.</param>
        /// <param name="availableBikeStands">availableBikeStands.</param>
        /// <param name="availableBikes">availableBikes.</param>
        /// <param name="status">status.</param>
        /// <param name="lastUpdate">lastUpdate.</param>
        public Station(int? number = default(int?), string contractName = default(string), string name = default(string), string address = default(string), StationPosition position = default(StationPosition), bool? banking = default(bool?), bool? bonus = default(bool?), int? bikeStands = default(int?), int? availableBikeStands = default(int?), int? availableBikes = default(int?), string status = default(string), long? lastUpdate = default(long?))
        {
            this.Number = number;
            this.ContractName = contractName;
            this.Name = name;
            this.Address = address;
            this.Position = position;
            this.Banking = banking;
            this.Bonus = bonus;
            this.BikeStands = bikeStands;
            this.AvailableBikeStands = availableBikeStands;
            this.AvailableBikes = availableBikes;
            this.Status = status;
            this.LastUpdate = lastUpdate;
        }
        
        /// <summary>
        /// Gets or Sets Number
        /// </summary>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or Sets ContractName
        /// </summary>
        [DataMember(Name="contract_name", EmitDefaultValue=false)]
        public string ContractName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name="position", EmitDefaultValue=false)]
        public StationPosition Position { get; set; }

        /// <summary>
        /// Gets or Sets Banking
        /// </summary>
        [DataMember(Name="banking", EmitDefaultValue=false)]
        public bool? Banking { get; set; }

        /// <summary>
        /// Gets or Sets Bonus
        /// </summary>
        [DataMember(Name="bonus", EmitDefaultValue=false)]
        public bool? Bonus { get; set; }

        /// <summary>
        /// Gets or Sets BikeStands
        /// </summary>
        [DataMember(Name="bike_stands", EmitDefaultValue=false)]
        public int? BikeStands { get; set; }

        /// <summary>
        /// Gets or Sets AvailableBikeStands
        /// </summary>
        [DataMember(Name="available_bike_stands", EmitDefaultValue=false)]
        public int? AvailableBikeStands { get; set; }

        /// <summary>
        /// Gets or Sets AvailableBikes
        /// </summary>
        [DataMember(Name="available_bikes", EmitDefaultValue=false)]
        public int? AvailableBikes { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdate
        /// </summary>
        [DataMember(Name="last_update", EmitDefaultValue=false)]
        public long? LastUpdate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Station {\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  ContractName: ").Append(ContractName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Banking: ").Append(Banking).Append("\n");
            sb.Append("  Bonus: ").Append(Bonus).Append("\n");
            sb.Append("  BikeStands: ").Append(BikeStands).Append("\n");
            sb.Append("  AvailableBikeStands: ").Append(AvailableBikeStands).Append("\n");
            sb.Append("  AvailableBikes: ").Append(AvailableBikes).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  LastUpdate: ").Append(LastUpdate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Station);
        }

        /// <summary>
        /// Returns true if Station instances are equal
        /// </summary>
        /// <param name="input">Instance of Station to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Station input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Number == input.Number ||
                    (this.Number != null &&
                    this.Number.Equals(input.Number))
                ) && 
                (
                    this.ContractName == input.ContractName ||
                    (this.ContractName != null &&
                    this.ContractName.Equals(input.ContractName))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
                ) && 
                (
                    this.Banking == input.Banking ||
                    (this.Banking != null &&
                    this.Banking.Equals(input.Banking))
                ) && 
                (
                    this.Bonus == input.Bonus ||
                    (this.Bonus != null &&
                    this.Bonus.Equals(input.Bonus))
                ) && 
                (
                    this.BikeStands == input.BikeStands ||
                    (this.BikeStands != null &&
                    this.BikeStands.Equals(input.BikeStands))
                ) && 
                (
                    this.AvailableBikeStands == input.AvailableBikeStands ||
                    (this.AvailableBikeStands != null &&
                    this.AvailableBikeStands.Equals(input.AvailableBikeStands))
                ) && 
                (
                    this.AvailableBikes == input.AvailableBikes ||
                    (this.AvailableBikes != null &&
                    this.AvailableBikes.Equals(input.AvailableBikes))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.LastUpdate == input.LastUpdate ||
                    (this.LastUpdate != null &&
                    this.LastUpdate.Equals(input.LastUpdate))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Number != null)
                    hashCode = hashCode * 59 + this.Number.GetHashCode();
                if (this.ContractName != null)
                    hashCode = hashCode * 59 + this.ContractName.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
                if (this.Banking != null)
                    hashCode = hashCode * 59 + this.Banking.GetHashCode();
                if (this.Bonus != null)
                    hashCode = hashCode * 59 + this.Bonus.GetHashCode();
                if (this.BikeStands != null)
                    hashCode = hashCode * 59 + this.BikeStands.GetHashCode();
                if (this.AvailableBikeStands != null)
                    hashCode = hashCode * 59 + this.AvailableBikeStands.GetHashCode();
                if (this.AvailableBikes != null)
                    hashCode = hashCode * 59 + this.AvailableBikes.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.LastUpdate != null)
                    hashCode = hashCode * 59 + this.LastUpdate.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
