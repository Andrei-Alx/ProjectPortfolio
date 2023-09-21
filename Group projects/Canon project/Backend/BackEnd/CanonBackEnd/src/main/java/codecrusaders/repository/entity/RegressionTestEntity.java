package codecrusaders.repository.entity;

import codecrusaders.domain.SubTest;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;
import java.util.Date;

@Entity
@Data
@Table(name = "tests")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class RegressionTestEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "testid")
    private Long id;
    @Column(name = "testname")
    private String testName;
    @Column(name = "testdate")
    private LocalDateTime testDate;


    @Column(name = "testsetid")
    private Long testSetId;

}
