package codecrusaders.repository.entity;

import codecrusaders.domain.RegressionTest;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.Date;
import java.util.List;

@Entity
@Data
@Table(name = "testsets")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class TestSetEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "testsetid")
    private Long id;
    @Column(name = "testsetname")
    private String testSetName;
    @Column(name = "testbatchid")
    private Long testBatchId;
    @Column(name = "testsettime")
    private Date testSetTime;




}
