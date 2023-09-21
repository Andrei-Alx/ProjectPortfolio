package codecrusaders.repository.entity;

import codecrusaders.domain.ErrorMessage;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import javax.persistence.*;

@Entity
@Data
@Table(name = "teststeps")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class TestStepEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "teststepid")
    private Long id;
    @Column(name = "teststepname")
    private String testStepName;
    @Column(name = "testresult")
    private boolean testResult;
    @Column(name = "errorid")
    private Long errorID;
    @Column(name = "description")
    private String description;
    @Column(name = "subtestid")
    private Long subTestID;
}
