
package org.tempuri;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import org.datacontract.schemas._2004._07.osmroutingclient.ArrayOfArrayOfPosition;


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
@XmlRootElement(name = "GetBestTrajetResponse")
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
