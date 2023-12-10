
package com.example.serverside;

import java.util.ArrayList;
import java.util.List;
import jakarta.xml.bind.annotation.XmlAccessType;
import jakarta.xml.bind.annotation.XmlAccessorType;
import jakarta.xml.bind.annotation.XmlElement;
import jakarta.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour ArrayOfArrayOfPosition complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfArrayOfPosition"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="ArrayOfPosition" type="{http://schemas.datacontract.org/2004/07/OSMRoutingClient}ArrayOfPosition" maxOccurs="unbounded" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfArrayOfPosition", propOrder = {
    "arrayOfPosition"
})
public class ArrayOfArrayOfPosition {

    @XmlElement(name = "ArrayOfPosition", nillable = true)
    protected List<ArrayOfPosition> arrayOfPosition;

    /**
     * Gets the value of the arrayOfPosition property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the Jakarta XML Binding object.
     * This is why there is not a <CODE>set</CODE> method for the arrayOfPosition property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getArrayOfPosition().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link ArrayOfPosition }
     * 
     * 
     */
    public List<ArrayOfPosition> getArrayOfPosition() {
        if (arrayOfPosition == null) {
            arrayOfPosition = new ArrayList<ArrayOfPosition>();
        }
        return this.arrayOfPosition;
    }

}
