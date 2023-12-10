
package com.example.serverside;

import jakarta.xml.bind.JAXBElement;
import jakarta.xml.bind.annotation.XmlAccessType;
import jakarta.xml.bind.annotation.XmlAccessorType;
import jakarta.xml.bind.annotation.XmlElementRef;
import jakarta.xml.bind.annotation.XmlRootElement;
import jakarta.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour anonymous complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="GetBestTrajetResult" type="{http://schemas.datacontract.org/2004/07/OSMRoutingClient}ArrayOfArrayOfPosition" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "getBestTrajetResult"
})
@XmlRootElement(name = "GetBestTrajetResponse", namespace = "http://tempuri.org/")
public class GetBestTrajetResponse {

    @XmlElementRef(name = "GetBestTrajetResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArrayOfPosition> getBestTrajetResult;

    /**
     * Obtient la valeur de la propriété getBestTrajetResult.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfPosition }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArrayOfPosition> getGetBestTrajetResult() {
        return getBestTrajetResult;
    }

    /**
     * Définit la valeur de la propriété getBestTrajetResult.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfPosition }{@code >}
     *     
     */
    public void setGetBestTrajetResult(JAXBElement<ArrayOfArrayOfPosition> value) {
        this.getBestTrajetResult = value;
    }

}
