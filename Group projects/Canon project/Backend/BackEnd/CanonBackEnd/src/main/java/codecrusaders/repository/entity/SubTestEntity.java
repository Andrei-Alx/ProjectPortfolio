package codecrusaders.repository.entity;

import codecrusaders.domain.TestStep;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Data
@Table(name = "subtests")
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class SubTestEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "subtestid")
    private Long id;
    @Column(name = "subtestname")
    private String subTestName;
    @Column(name = "testid")
    private Long testID;
}
