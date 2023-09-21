package codecrusaders.repository.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@Table(name = "errors")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class ErrorEntity {
    @Id
    @Column(name = "errorid")
    private Long errorid;
    @Column(name = "errormessage")
    private String errorMessage;
}
